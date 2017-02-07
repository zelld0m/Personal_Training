using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipR.Entities;
using ShipR.Business;
using System.Collections;

namespace Shipr.lib
{
    public partial class PromoType : System.Web.UI.UserControl
    {
        public List<ShipR.Entities.PromoType> SourcePromoType { get; set; }
        public List<ShipR.Entities.DiscountType> SourceDiscountType { get; set; }
        public int PromoTypeID { get; set; }
        public string Text { get; set; }
        public string DollarMin { get; set; }
        public string DollarMax { get; set; }
        public string WeightMin { get; set; }
        public string WeightMax { get; set; }
        public string ExcludedSkus { get; set; } //CRF48287 Gilbert -  exclude feature. 7/8/2014
        public string Qualifiers { get; set; }
        public string Title { get; set; }
        public Boolean isIncreasePercent { get; set; }
        public string IncreasePercent { get; set; }
        public string IncreaseDollar { get; set; }
        public string IncreaseWeightThreshold { get; set; }
        public string IncreaseDollarThreshold { get; set; }        
        public string CategoryCodes { get; set; }
        public string Manufacturers { get; set; }
        public string PaymentMethods { get; set; }
        public double DiscountValue { get; set; }
        public double IncreaseFreight { get; set; }
        public bool FullOrderOrExactPromo { get; set; }

        public int DiscountTypeID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            loadReference();
            if (PromoTypeID > 0)
            {
                uxType.SelectedValue = PromoTypeID.ToString();
                uxDollarMin.Text = DollarMin;
                uxDollarMax.Text = DollarMax;
                uxWeightMin.Text = WeightMin;
                uxWeightMax.Text = WeightMax;
                chkExactPromo.Checked = FullOrderOrExactPromo;
                uxDiscountValue.Text = DiscountValue.ToString();
                uxDiscountType.Visible = true;

                if (PromoTypeID == 2) //category
                    loadCategoryCodes();
                else if (PromoTypeID == 3) //Manufacturer
                    loadManufactures();
                else if (PromoTypeID == 4) //sku level
                    loadSkus();
                else if (PromoTypeID == 5) //Payment Method
                    loadPaymentMethods();
                else if (PromoTypeID == 6) //Increase Freight 
                {
                    if (Convert.ToDouble(IncreasePercent) > 0) //0-Increase percent, 1-Increase dollar
                    {
                        drpIncreaseBox.SelectedIndex = 0;
                        uxIncreasePercent.Visible = true;
                        uxIncreaseDollar.Visible = false;
                    }
                    else
                    {
                        drpIncreaseBox.SelectedIndex = 1;
                        uxIncreasePercent.Visible = false;
                        uxIncreaseDollar.Visible = true;
                    }

                    uxDiscountValue.Text = IncreaseFreight.ToString();
                    uxIncreasePercent.Text = IncreasePercent.ToString();
                    uxIncreaseDollar.Text = IncreaseDollar.ToString();
                    uxIncreaseWeightThreshold.Text=IncreaseWeightThreshold.ToString();
                    uxIncreaseDollarThreshold.Text=IncreaseDollarThreshold.ToString();
                }
                else
                {
                    listSkus.Text = Qualifiers;
                    uxIncreasePercent.Text = IncreasePercent;
                    uxIncreaseDollar.Text = IncreaseDollar;
                }
                //CRF48287 - exclude feature
                if (ExcludedSkus != null)
                    loadExcludeSkus();
                //end CRF48287
            }
            else
            {
                PromoTypeID = Convert.ToInt32(uxType.SelectedValue);
                DiscountTypeID = Convert.ToInt32(ddlDiscountType.SelectedValue);
                Text = uxType.SelectedItem.Text;
                DollarMin = uxDollarMin.Text;
                DollarMax = uxDollarMax.Text;
                WeightMax = uxWeightMax.Text;
                WeightMin = uxWeightMin.Text;
                FullOrderOrExactPromo = chkExactPromo.Checked;
                IncreasePercent = uxIncreasePercent.Text;
                IncreaseDollar = uxIncreaseDollar.Text;
                DiscountValue = Convert.ToDouble((uxDiscountValue.Text.Equals("") ? "0" : uxDiscountValue.Text));
                IncreaseWeightThreshold= (uxIncreaseWeightThreshold.Text.Equals("") ? "0" : uxIncreaseWeightThreshold.Text);
                IncreaseDollarThreshold= (uxIncreaseDollarThreshold.Text.Equals("") ? "0" : uxIncreaseDollarThreshold.Text);

                if (PromoTypeID == 2)//category
                    CategoryCodes = uxLabelSelectedCategory.Text;
                else if (PromoTypeID == 3)//manufacturer
                    Manufacturers = getSelectedManufacturers();
                else if (PromoTypeID == 5)//paymentmethod
                    PaymentMethods = getSelectedPaymentMethods();
                else if (PromoTypeID == 6)//discountytpe- increase freidgth
                {
                    //DiscountValue = Convert.ToDouble((uxDiscountValue.Text.Equals("")?"0":uxDiscountValue.Text));                    
                    if (drpIncreaseBox.SelectedIndex == 0) //0-Increase percent, 1-Increase dollar
                        isIncreasePercent = true;
                    else
                        isIncreasePercent = false;
                }
                else if (PromoTypeID == 4)//sku level
                    Qualifiers = getEdpList();
                //CRF48287 Gilbert -  exclude feature. 7/8/2014
                else if (PromoTypeID == 1)// sitewide
                    ExcludedSkus = getEdpList();
                //end CRF48287
            }
            uxTitle.Text = (Title != null) ? Title : "Promotion type";
            viewControlsByType();
        }

        #region loadReference

        private void loadReference()
        {
            if (SourcePromoType != null)
            {
                uxType.DataSource = SourcePromoType;
                uxType.DataValueField = "PromoTypeID";
                uxType.DataTextField = "PromoTypeDesc";
                uxType.DataBind();
            }

            if (SourceDiscountType != null)
            {
                ShipR.Entities.DiscountType dt = new ShipR.Entities.DiscountType();
                dt.DiscountTypeID = 0;
                dt.DiscountTypeDesc = "-";
                dt.DetailedDesc = "-";
                SourceDiscountType.Insert(0, dt);
                ddlDiscountType.DataSource = SourceDiscountType;
                ddlDiscountType.DataValueField = "DiscountTypeID";
                ddlDiscountType.DataTextField = "DiscountTypeDesc";
                uxDiscountType.DataBind();
                if (DiscountTypeID <= 0)

                    ddlDiscountType.SelectedIndex = 2;
                else
                    ddlDiscountType.SelectedIndex = DiscountTypeID;
            }
        }

        #endregion

        #region CategoryCodes_
        protected void uxCategoryCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignCatCodesToLabel();
            loadSubMajor();
            loadMinor();
            loadSubMinor();
            uxDrpSubMajor.SelectedIndex = 0;
            uxDrpMinor.SelectedIndex = 0;
            uxDrpSubMinor.SelectedIndex = 0;
        }

        protected void uxSubMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignCatCodesToLabel();
            loadMinor();
            loadSubMinor();
            uxDrpMinor.SelectedIndex = 0;
            uxDrpSubMinor.SelectedIndex = 0;
        }

        protected void uxMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignCatCodesToLabel();
            loadSubMinor();
            uxDrpSubMinor.SelectedIndex = 0;

        }

        protected void uxSubMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignCatCodesToLabel();
        }

        private void assignCatCodesToLabel()
        {
            uxLabelSelectedCategory.Text = (uxDrpCategory.SelectedValue.ToString().Equals("-") ? "" : uxDrpCategory.SelectedValue.ToString()) +
                                            (uxDrpSubMajor.SelectedValue.ToString().Equals("-") || uxDrpCategory.SelectedValue.ToString().Equals("-") ? "" : uxDrpSubMajor.SelectedValue.ToString()) +
                                            (uxDrpMinor.SelectedValue.ToString().Equals("-") || uxDrpCategory.SelectedValue.ToString().Equals("-") ? "" : uxDrpMinor.SelectedValue.ToString()) +
                                            (uxDrpSubMinor.SelectedValue.ToString().Equals("-") || uxDrpCategory.SelectedValue.ToString().Equals("-") ? "" : uxDrpSubMinor.SelectedValue.ToString());

            CategoryCodes = uxLabelSelectedCategory.Text;
        }

        private void setCategoryCodes()
        {
            int x = 0;
            foreach (char cat in CategoryCodes.ToString())
            {
                if (x == 0) //major
                {
                    uxDrpCategory.SelectedValue = cat.ToString();
                    loadSubMajor();
                    loadMinor();
                    loadSubMinor();
                }
                else if (x == 1) //submajor
                {
                    loadSubMajor();
                    loadMinor();
                    loadSubMinor();
                    uxDrpSubMajor.SelectedValue = cat.ToString();
                }
                else if (x == 2) //minor
                {
                    loadMinor();
                    loadSubMinor();
                    uxDrpMinor.SelectedValue = cat.ToString();
                }
                else if (x == 3) //subminor
                {
                    loadSubMinor();
                    uxDrpSubMinor.SelectedValue = cat.ToString();
                }
                x++;
            }
        }

        private void loadCategoryCodes()//major
        {
            DataTable dt = PromoManagement.GetCategoryMajors().Tables[0];
            // combine the category name with the [ltr]...
            DataColumn myColumn = new DataColumn();
            myColumn.ColumnName = "combo";
            myColumn.DataType = System.Type.GetType("System.String");
            myColumn.Expression = "WDMajor+' ['+ltrMajor+']'";
            dt.Columns.Add(myColumn);

            DataRow dr = dt.NewRow();
            dr["combo"] = "--select category--";
            dr["ltrMajor"] = "-"; //0 already used as value (Office Supplies & Equipment)
            dt.Rows.InsertAt(dr, 0);

            DataView dv = dt.DefaultView;
            uxDrpCategory.DataSource = dv;
            uxDrpCategory.DataValueField = "ltrMajor";
            uxDrpCategory.DataTextField = "combo";
            uxDrpCategory.DataBind();
            if (CategoryCodes.Length == 0)
                uxDrpCategory.SelectedIndex = 0;
            uxCategoryCodes.Visible = true;
            uxDrpCategory.Visible = true;
            //uxDetails.Visible = false;
            uxDetails.Visible = true; //CRF48287 - exclude feature.
            uxLabelCategorycodes.Visible = true;
            uxLabelSelectedCategory.Text = CategoryCodes;
            uxLabelSelectedCategory.Visible = true;
            if (CategoryCodes.Length > 0)
                setCategoryCodes();
        }

        private void loadSubMajor()
        {
            DataTable dt = PromoManagement.GetSubMajors(Convert.ToChar(uxDrpCategory.SelectedValue)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                // combine the category name with the [ltr]...
                DataColumn myColumn = new DataColumn();
                myColumn.ColumnName = "combo";
                myColumn.DataType = System.Type.GetType("System.String");
                myColumn.Expression = "SubMajor+' ['+ltrSubMajor+']'";
                dt.Columns.Add(myColumn);

                DataRow dr = dt.NewRow();
                dr["combo"] = "--select sub-major--";
                dr["ltrSubMajor"] = "-";
                dt.Rows.InsertAt(dr, 0);

                DataView dv = dt.DefaultView;
                uxDrpSubMajor.DataSource = dv;
                uxDrpSubMajor.DataValueField = "ltrSubMajor";
                uxDrpSubMajor.DataTextField = "combo";
                uxDrpSubMajor.DataBind();
            }
            else
            {
                uxDrpSubMajor.Items.Clear();
                uxDrpSubMajor.Items.Add(new ListItem("--select category--", "-"));
                uxDrpSubMajor.SelectedIndex = 0;
            }    
            uxDrpSubMajor.Visible = true;
            uxLabelSubMajor.Visible = true;
        }

        private void loadMinor()
        {
            DataTable dt = PromoManagement.GetMinors(Convert.ToChar(uxDrpCategory.SelectedValue), Convert.ToChar(uxDrpSubMajor.SelectedValue)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                // combine the category name with the [ltr]...
                DataColumn myColumn = new DataColumn();
                myColumn.ColumnName = "combo";
                myColumn.DataType = System.Type.GetType("System.String");
                myColumn.Expression = "minor+' ['+ltrminor+']'";
                dt.Columns.Add(myColumn);

                DataRow dr = dt.NewRow();
                dr["ltrminor"] = "-";
                dr["combo"] = "--select minor--";
                dt.Rows.InsertAt(dr, 0);
                DataView dv = dt.DefaultView;
                uxDrpMinor.DataSource = dv;
                uxDrpMinor.DataValueField = "ltrminor";
                uxDrpMinor.DataTextField = "combo";
                uxDrpMinor.DataBind(); 
            }
            else
            {
                uxDrpMinor.Items.Clear();
                uxDrpMinor.Items.Add(new ListItem("--select sub major--","-"));
                uxDrpMinor.SelectedIndex=0;
            }    
                
            uxDrpMinor.Visible = true;
            uxLabelMinor.Visible = true;
        }

        private void loadSubMinor()
        {
            DataTable dt = PromoManagement.GetSubMinors(Convert.ToChar(uxDrpCategory.SelectedValue), Convert.ToChar(uxDrpSubMajor.SelectedValue), Convert.ToChar(uxDrpMinor.SelectedValue)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                // combine the category name with the [ltr]...
                DataColumn myColumn = new DataColumn();
                myColumn.ColumnName = "combo";
                myColumn.DataType = System.Type.GetType("System.String");
                myColumn.Expression = "subMinor+' ['+ltrsubMinor+']'";
                dt.Columns.Add(myColumn);

                DataRow dr = dt.NewRow();
                dr["combo"] = "--select sub-minor--";
                dr["ltrsubMinor"] = "-";
                dt.Rows.InsertAt(dr, 0);

                DataView dv = dt.DefaultView;
                uxDrpSubMinor.DataSource = dv;
                uxDrpSubMinor.DataValueField = "ltrsubMinor";
                uxDrpSubMinor.DataTextField = "combo";
                uxDrpSubMinor.DataBind();
            }
            else
            {
                uxDrpSubMinor.Items.Clear();
                uxDrpSubMinor.Items.Add(new ListItem("--select minor--", "-"));
                uxDrpSubMinor.SelectedIndex = 0;
            }    
            uxDrpSubMinor.Visible = true;
            uxLabelSubMinor.Visible = true;
        }

        #endregion

        #region Manufacturers

        private string getSelectedManufacturers()
        {
            String mList = "";
            uxDdlManufacturersSelected.Items.Clear();
            string[] manufacturerArray = hiddenManufacturers.Value.Split(',');
            for (int i = 0; i < manufacturerArray.Length; i++)
            {
                if (manufacturerArray[i].Trim().Length > 0)
                {
                    mList += (mList.Length == 0 ? manufacturerArray[i].ToString() : "," + manufacturerArray[i].ToString());
                   ListItem item= uxDdlManufacturers.Items.FindByValue(manufacturerArray[i]); ;
                    if (item!=null)
                        uxDdlManufacturersSelected.Items.Add(new ListItem(manufacturerArray[i].Trim(), item.Value));
                }
            }
            return mList;
        }


        private void setManufacturers()
        {
            //assign to selected manufacturers listbox
            string[] manufacturerArray = Manufacturers.Split(',');          
            for (int i = 0; i < uxDdlManufacturers.Items.Count; i++)
            {
                if (FindValueFromArray(manufacturerArray, uxDdlManufacturers.Items[i].Value) == true && uxDdlManufacturers.Items[i].Value.ToString().Trim().Length > 0)
                {
                    uxDdlManufacturersSelected.Items.Add(new ListItem(uxDdlManufacturers.Items[i].Text,uxDdlManufacturers.Items[i].Value));
                    uxDdlManufacturers.Items.Remove(new ListItem(uxDdlManufacturers.Items[i].Text, uxDdlManufacturers.Items[i].Value));
                }
            }

            //assign to hidden field
            String mList = "";
            for (int i = 0; i < manufacturerArray.Length; i++)
            {
                if (manufacturerArray[i].Trim().Length > 0)
                     mList += (mList.Length == 0 ? manufacturerArray[i].ToString() : "," + manufacturerArray[i].ToString());
            }
            if (mList.Length > 0)
                hiddenManufacturers.Value = mList;
        }
        #endregion

        #region Payment Methods
        private string getSelectedPaymentMethods()
        {
            string paymentMethods = "";
            for (int i = 0; i < uxDdlPaymentMethod.Items.Count; i++)
            {
                if (uxDdlPaymentMethod.Items[i].Selected == true)
                    paymentMethods += (paymentMethods.Length > 0 ? "," : "") + uxDdlPaymentMethod.Items[i].Value.ToString();
            }
            return paymentMethods;
        }

        private void loadPaymentMethods()
        {
            Hashtable dt = PromoManagement.GetAllPaymentMethods();
            uxDdlPaymentMethod.DataSource = dt;
            uxDdlPaymentMethod.DataValueField = "Key";
            uxDdlPaymentMethod.DataTextField = "Value";
            uxDdlPaymentMethod.DataBind();
            if (PaymentMethods.Length == 0)
                uxDdlPaymentMethod.SelectedIndex = 0;
            uxPaymentMethod.Visible = true;
            uxLabelPaymentMethod.Visible = true;
            uxLabelSelectedPayment.Visible = true;
            uxLabelSelectedPayment.Text = PaymentMethods;

            if (PaymentMethods.Length > 0)
                setPaymentMethods();
        }

        private void setPaymentMethods()
        {
            string[] paymentMethodArray = PaymentMethods.Split(',');
            for (int i = 0; i < uxDdlPaymentMethod.Items.Count; i++)
            {
                if (FindValueFromArray(paymentMethodArray, uxDdlPaymentMethod.Items[i].Value) == true && uxDdlPaymentMethod.Items[i].Value.ToString().Trim().Length > 0)
                    uxDdlPaymentMethod.Items[i].Selected = true;
            }
        }

        private void loadManufactures()

        {
            DataTable dt = PromoManagement.GetAllManufacturers().Tables[0];
            uxDdlManufacturers.DataSource = dt;
            uxDdlManufacturers.DataValueField = "vendno";
            uxDdlManufacturers.DataTextField = "Manufacturer";
            uxDdlManufacturers.DataBind();
            if (Manufacturers.Length == 0)
                uxDdlManufacturers.SelectedIndex = 0;
            uxManufacturers.Visible = true;
            uxLabelManufacturers.Visible = true;
            //uxLabelSelectedManufacturer.Visible = true;
            uxLabelSelectedManufacturer.Text = Manufacturers;

            if (Manufacturers.Length > 0)
                setManufacturers();
        }


        #endregion

        #region Sku Level
        private void loadSkus()
        {
            String sList = "";
            listSkus.Items.Clear();
            string[] skuArray = Qualifiers.Split(',');
            for (int i = 0; i < skuArray.Length; i++)
            {
                if (skuArray[i].Trim().Length > 0)
                {
                    //sList += (sList.Length == 0 ? skuArray[i].ToString() : "," + skuArray[i].ToString());
                    int sku =PromoManagement.GetDpByEdp(Convert.ToInt32(skuArray[i]));
                    if (sku > 0)
                    {
                        sList += (sList.Length == 0 ? sku.ToString() : "," + sku.ToString());
                        listSkus.Items.Add(new ListItem(sku.ToString()));
                    }
                }
            }
            
            //assign to hidden field            
            if (sList.Length > 0)
                hiddenSkus.Value = sList;
        }
        //CRF48287 - exclude feature
        private void loadExcludeSkus()
        {
            String sList = "";
            listSkus.Items.Clear();
            string[] skuArray = ExcludedSkus.Split(',');
            for (int i = 0; i < skuArray.Length; i++)
            {
                if (skuArray[i].Trim().Length > 0)
                {
                    //sList += (sList.Length == 0 ? skuArray[i].ToString() : "," + skuArray[i].ToString());
                    int sku = Convert.ToInt32(skuArray[i]);
                    if (sku > 0)
                    {
                        sList += (sList.Length == 0 ? sku.ToString() : "," + sku.ToString());
                        listSkus.Items.Add(new ListItem(sku.ToString()));
                    }
                }
            }

            //assign to hidden field            
            if (sList.Length > 0)
                hiddenSkus.Value = sList;
        }
        //end CRF48287

        private string getEdpList()
        {
            String skuList = "";
            listSkus.Items.Clear();
            string[] skuArray = hiddenSkus.Value.Split(',');
            for (int i = 0; i < skuArray.Length; i++)   
            {
                if (skuArray[i].Trim().Length > 0)
                {
                    skuList+=(skuList.Length==0?PromoManagement.GetEdpByDp(Convert.ToInt32(skuArray[i])).ToString():"," + PromoManagement.GetEdpByDp(Convert.ToInt32(skuArray[i])).ToString());
                    listSkus.Items.Add(new ListItem(skuArray[i].Trim()));
                }                                    
            }
            return skuList;
        }

        #endregion

        #region uxDiscountType_SelectedIndexChanged
        protected void uxDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiscountTypeID = Convert.ToInt32(ddlDiscountType.SelectedValue);
            if (ddlDiscountType.SelectedIndex == 0 || ddlDiscountType.SelectedIndex == 1 || ddlDiscountType.SelectedIndex == 5) //1:Free and 0:no selected , 5: None
            {
                uxDiscountLabel.Visible = false;
                uxDiscountValue.Visible = false;
            }
            else
            {
                if (ddlDiscountType.SelectedIndex == 4) //exact dollar charge
                    uxDiscountLabel.Text = "Shipping Charge: $";
                else if (ddlDiscountType.SelectedIndex == 3) //percent discount
                    uxDiscountLabel.Text = "Percent Value: %";
                else
                    uxDiscountLabel.Text = "Discount Value:$";

                uxDiscountLabel.Visible = true;
                uxDiscountValue.Visible = true;
            }
        }

        protected void uxType_SelectedIndexChanged(object sender, EventArgs e)
        {

            viewControlsByType();
            if (Convert.ToInt32(uxType.SelectedValue) == 2) //category
                loadCategoryCodes();
            else if (PromoTypeID == 3) //Manufacturer
                loadManufactures();
            else if (PromoTypeID == 5) //Payment method
                loadPaymentMethods();
        }

        protected void drpIncreaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (drpIncreaseBox.SelectedIndex == 0) //0-Increase percent, 1-Increase dollar
            {
                uxIncreaseDollar.Visible = false;
                uxIncreaseDollar.Text = "0";
                uxIncreasePercent.Visible = true;
                isIncreasePercent = true;
            }
            else
            {
                uxIncreaseDollar.Visible = true;
                uxIncreasePercent.Visible = false;
                uxIncreasePercent.Text = "0";
                isIncreasePercent = false;
            }
        }

        #endregion

        #region void
        private void viewControlsByType()
        {
            string label = "";
            switch (uxType.SelectedValue)
            {
                case "1": //Sitewide
                    label = "Sitewide";
                    //setControlsVisible(true, true, false, false, false, false, false, false, true);
                    setControlsVisible(true, true, false, true, false, false, true, false, true);//CRF48287 - exclude feature
                    break;
                case "2": //Categories //dropdown  
                    label = "Category Code:";
                    //setControlsVisible(true, true, false, false, false, true, false, false, true);
                    setControlsVisible(true, true, false, true, false, true, true, false, true);//CRF48287 - exclude feature
                    break;
                case "3": //Manufacturers //dropdown
                    label = "Manufacturer:";
                    //setControlsVisible(true, true, false, false, true, false, false, false, true);
                    setControlsVisible(true, true, false, true, true, false, true, false, true);//CRF48287 - exclude feature
                    break;
                case "4": //SKULevel
                    label = "SKU/s:";
                    uxLabel.Visible = true;
                    listSkus.Width = 120;
                    setControlsVisible(true, true, false, true, false, false, true, false, true);
                    break;
                case "5": //PaymentMethod //dropdown bml,preferred,open-account,paypal,creditcard
                    label = "Payment method:";
                    //setControlsVisible(true, true, false, true,false, false, false, true, true);
                    setControlsVisible(true, true, false, true, false, false, true, true, true);//CRF48287 - exclude feature
                    label = uxType.SelectedItem.Text;
                    break;
                case "6": //IncreaseFreight
                    label = "Increase Freight:";
                    //setControlsVisible(true, true, true, false, false, false , false, false,false);
                    setControlsVisible(true, true, true, true, false, false, true, false, false);//CRF48287 - exclude feature
                    break;
            }
        }

        private void setControlsVisible(bool weightMax, bool orderLevel, bool increasePercent, bool skuLevel, bool manufacturer, bool category, bool detail, bool paymentMethod, bool discount)
        {
            divWeightMax.Visible = weightMax;
            uxOrderLevel.Visible = orderLevel;
            divIncreasePercent.Visible = increasePercent;
            listSkus.Visible = skuLevel;
            uxDetails.Visible = detail;
            //CRF48287 - Exclude feature
            if (uxType.SelectedValue != "4")
                uxLabel.Text = "Exclude Sku*:";
            else
                uxLabel.Text = "Sku*:";
            //end CRF48287
            uxManufacturers.Visible = manufacturer;
            uxLabelManufacturers.Visible = manufacturer;
            //uxLabelSelectedManufacturer.Visible = manufacturer;
            uxLabelCategorycodes.Visible = category;
            uxCategoryCodes.Visible = category;
            uxLabelCategorycodes.Visible = category;
            uxPaymentMethod.Visible = paymentMethod;
            uxLabelPaymentMethod.Visible = paymentMethod;
            uxLabelPaymentMethod.Visible = paymentMethod;
            uxDiscountType.Visible = discount;
            if (DiscountTypeID <= 1)
            {
                uxDiscountLabel.Visible = !discount;
                uxDiscountValue.Visible = !discount;
            }
            else
            {
                uxDiscountLabel.Visible = discount;
                uxDiscountValue.Visible = discount;
            }

            if (ddlDiscountType.SelectedIndex == 5)//none
            {
                uxDiscountLabel.Visible = false;
                uxDiscountValue.Visible = false;
                uxDiscountValue.Text = "0";
            }

        }

        public static bool FindValueFromArray(object[] Values, object valueToSearch)
        {
            bool retVal = false;
            Array myArray = (Array)Values;
            for (int x = 0; x < myArray.Length; x++)
            {
                if (myArray.GetValue(x).ToString().Equals(valueToSearch))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;

        }
        #endregion
    }
}