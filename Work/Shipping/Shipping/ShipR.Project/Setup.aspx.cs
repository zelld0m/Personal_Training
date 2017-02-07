using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Shipr;
using ShipR.Entities;
using ShipR.Business;

namespace Shipr
{
    public partial class Setup : System.Web.UI.Page
    {
        List<string> problemFields = new List<string>();
        String imgServerLink = ConfigurationManager.AppSettings["ImgServer"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl body = (HtmlGenericControl)this.Page.Master.FindControl("body");
            body.Attributes.Add("class", "setup");
            Lookup lookup;
            Promo promo;
            if (!IsPostBack)
            {
                lookup = PromoManagement.GetGenericLookUp();
                uxStore.Source = lookup.Stores;
                uxShipMethod.Source = lookup.Shippings;
                uxPromoType.SourcePromoType = lookup.PromoTypes;
                uxPromoType.SourceDiscountType = lookup.DiscountTypes;
                if (Request.QueryString["promoID"] != null)
                {
                    promo = PromoManagement.GetPromoByPromoID(Convert.ToInt32(Request.QueryString["promoID"]));
                    loadPromo(promo);
                }
            }
        }

        private void loadPromo(Promo promo)         /// SHOWS  CURRENT DETAIL OF PROMO THAT HAS BEEN SELECTED TO BE EDIT OR UPDATED
        {
            //promo name
            uxPromoTypeName.Value = promo.Name;

            //promo type
            uxPromoType.PromoTypeID = promo.promoTypeId;
            if (promo.promoTypeId == 2) //category
                uxPromoType.CategoryCodes = promo.promoExtras;
            else if (promo.promoTypeId == 3) //manufacturer
                uxPromoType.Manufacturers = promo.promoExtras;
            else if (promo.promoTypeId == 5) //paymentMethod
                uxPromoType.PaymentMethods = promo.promoExtras;
            else if (promo.promoTypeId == 6) //increase freight
            {
                uxPromoType.IncreaseWeightThreshold = Convert.ToString(promo.increaseWeightThreshold);
                uxPromoType.IncreaseDollarThreshold = Convert.ToString(promo.increaseDollarThreshold);
                uxPromoType.IncreasePercent = promo.increasePercent.ToString();
                uxPromoType.IncreaseDollar = promo.increaseDollar.ToString();

            }
            else
                uxPromoType.Qualifiers = promo.promoExtras;
            //CRF48287 - add exclude feature 07/15/2014
            if (promo.excludeSkus.Length > 0)
                uxPromoType.ExcludedSkus = promo.excludeSkus;
            //end CRF48287
            //dollar min and max
            uxPromoType.DollarMin = promo.dollarMin.ToString();
            uxPromoType.DollarMax = promo.dollarMax.ToString();            

            //weight min and max
            uxPromoType.WeightMin = promo.weightMin.ToString();
            uxPromoType.WeightMax = promo.weightMax.ToString();
            uxPromoType.FullOrderOrExactPromo = promo.fullOrderOrExactPromo;

            //discount
            uxPromoType.DiscountTypeID = promo.DiscountType.DiscountTypeID;
            uxPromoType.DiscountValue = promo.discount;

            //stores
            uxStore.SelectedStores = promo.Stores;

            //shipmethod
            uxShipMethod.SelectedShipping = promo.Shipping;

            //duration           
            uxDuration.StartDate = Convert.ToDateTime(promo.startDate).ToShortDateString();
            uxDuration.EndDate = Convert.ToDateTime(promo.endDate).ToShortDateString();
            uxDuration.StartTime = Convert.ToDateTime(promo.startDate).ToShortTimeString();
            uxDuration.EndTime = Convert.ToDateTime(promo.endDate).ToShortTimeString();
            //Text
            String savedText = promo.merchandisingTextPdp;
            uxPdpShipPromoText.Value = promo.merchandisingTextPdp;
            uxCheckoutMerchandisingText.Value = promo.merchandisingTextCheckout;
            uxSearchMerchandisingText.Value = promo.merchandisingTextSearch;
            //CheckBox
            if (promo.IsMerchVisible == 0) {
                chkIsMerchVisible.Checked = true;
            } else {
                chkIsMerchVisible.Checked = false;
            }
            


        }
        protected void uxSubmit_Click(object sender, EventArgs e)  // CLICK
        {
            int hasExclusions = 0; //TO DO: add logic for exclusions
            int status = 0; //turn off by default; TO DO: add logic for setting status automatically
            string createdBy = Request.ServerVariables["LOGON_USER"]; //TO DO: obtain from security module
            int userSubscriptionId = 0;
            string comments = "test comment";
            bool fullOrderOrExactPromo = true ;
            #region promo rules
            double dollarMax = 0.0;
            double weightMin = 0.0;
            double increasePercent = 0.0;
            double increaseDollar = 0.0;
            double increaseWeightThreshold = 0.0;
            double increaseDollarThreshold = 0.0;
            string promoQualifiers = null;
            string excludeCategoryCodes = null; //TO DO
            string excludeManufacturers = null; //TO DO
            string excludeSkus = null; //CRF48287
            string excludePayMethodIds = null; //TO DO
            string excludeCompanyIds = null; //TO DO
            string excludeZoneIds = null; //TO DO
            #endregion
            string shipMethodId = null;
            string shipMethodName = null;
            string promoType = uxPromoType.PromoTypeID.ToString();
            double dollarMin = 0.0;
            double weightMax = 0.0;
            string stores = "";
            string discountType = "";
            string discountValue = "0";
            List<KeyValuePair<string, string>> shipMethod = null;


            if (isValidated() == false)
            {
                uxPromoSetupMessageContent.Text = "Please check inputs for :<br/ >" + String.Join("<br/> ", problemFields.ToArray());
                uxPromoSetupMessage.Visible = true;
                uxPromoSetupMessageContent2.Text = "Please check inputs for :<br/ >" + String.Join("<br/> ", problemFields.ToArray());
                uxPromoSetupMessage2.Visible = true;
            }
            else
            {
                dollarMin = Convert.ToDouble(uxPromoType.DollarMin);
                dollarMax =  Convert.ToDouble(uxPromoType.DollarMax);
                weightMin = Convert.ToDouble(uxPromoType.WeightMin);
                weightMax = Convert.ToDouble(uxPromoType.WeightMax);
                fullOrderOrExactPromo = uxPromoType.FullOrderOrExactPromo;
                increasePercent = (uxPromoType.IncreasePercent == null || uxPromoType.IncreasePercent.Length == 0 ? 0 : Convert.ToDouble(uxPromoType.IncreasePercent));
                increaseDollar = (uxPromoType.IncreasePercent == null || uxPromoType.IncreaseDollar.Length == 0 ? 0 : Convert.ToDouble(uxPromoType.IncreaseDollar));

                increaseWeightThreshold = (uxPromoType.IncreaseWeightThreshold == null || uxPromoType.IncreaseWeightThreshold.ToString().Length == 0 ? 0 : Convert.ToDouble(uxPromoType.IncreaseWeightThreshold));
                increaseDollarThreshold = (uxPromoType.IncreaseDollarThreshold == null || uxPromoType.IncreaseDollarThreshold.ToString().Length == 0 ? 0 : Convert.ToDouble(uxPromoType.IncreaseDollarThreshold));

#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                discountType = (uxPromoType.DiscountTypeID == null ? "" : uxPromoType.DiscountTypeID.ToString());
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'double' is never equal to 'null' of type 'double?'
                discountValue = (uxPromoType.DiscountValue == null ? "0" : uxPromoType.DiscountValue.ToString());
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'double' is never equal to 'null' of type 'double?'
                if (uxPromoType.PromoTypeID == 2) //category
                    promoQualifiers = uxPromoType.CategoryCodes;
                else if (uxPromoType.PromoTypeID == 3) //manufacturers
                    promoQualifiers = uxPromoType.Manufacturers;
                else if (uxPromoType.PromoTypeID == 5) //paymentMethods
                    promoQualifiers = uxPromoType.PaymentMethods;
                else if (uxPromoType.PromoTypeID == 6) //Increasefreight
                {
                    discountType = "5";//none
                    discountValue="0";
                }
                else if (uxPromoType.PromoTypeID == 4) //Sku level. ////CRF48287 - exclude feature. added by Gilbert 7/8/2014
                    promoQualifiers = (uxPromoType.Qualifiers == null ? "" : uxPromoType.Qualifiers.Replace(Environment.NewLine, ","));
                //CRF48287 - exclude feature. added by Gilbert 7/8/2014
                if (!uxPromoType.PromoTypeID.Equals(4))
                {
                    excludeSkus = (uxPromoType.ExcludedSkus == null ? "" : uxPromoType.ExcludedSkus.Replace(Environment.NewLine, ","));
                    if (excludeSkus.Length > 0)
                        hasExclusions = 1;
                }
                //end CRF48287
                stores = GetSelectedItems(uxStore.Items);
           
                DateTime startDate = Convert.ToDateTime(uxDuration.StartDate + " " + uxDuration.StartTime);
                DateTime endDate = Convert.ToDateTime(uxDuration.EndDate + " " + uxDuration.EndTime);
                ///if ((DateTime.Now.CompareTo(startDate) >= 0) && (DateTime.Now.CompareTo(endDate) <= 0)) 
                status = 1;
                shipMethod = (uxShipMethod.Items == null ? null : uxShipMethod.Items);
                uxPromoSetupMessageContent.Text = null;
                uxPromoSetupMessage.Visible = false;
                uxPromoSetupMessageContent2.Text = null;
                uxPromoSetupMessage2.Visible = false;
                try
                {
                    foreach (KeyValuePair<string, string> kp in shipMethod)
                    {
                        shipMethodId = kp.Key;
                        shipMethodName = kp.Value;

                        Promo promo = new Promo();
                        Int32 promoID = 0;
                        if (Request.QueryString["promoID"] != null)
                        {
                            promoID = Convert.ToInt32(Request.QueryString["promoID"].ToString());
                            promo.promoID = (Convert.ToInt32(Request.QueryString["promoID"].ToString()) > 0 ? promoID : 0);
                        }
                        promo.promoTypeId = Convert.ToInt32(promoType);
                        promo.Name = uxPromoTypeName.Value;
                        promo.discountTypeId = Convert.ToInt32(discountType);
                        promo.discount = Convert.ToDouble((discountValue.Trim().Length == 0 ? "0" : discountValue));
                        promo.hasExcludes = hasExclusions;
                        promo.startDate = Convert.ToString(startDate);
                        promo.endDate = Convert.ToString(endDate);
                        promo.status = status;
                        promo.createdBy = createdBy;
                        promo.userSubscriptionId = userSubscriptionId;
                        promo.merchandisingTextCheckout = (uxCheckoutMerchandisingText.Text.Length > 500 ? uxCheckoutMerchandisingText.GetHtml().Substring(0, 499) : uxCheckoutMerchandisingText.GetHtml());
                        promo.merchandisingTextSearch = (uxSearchMerchandisingText.Text.Length > 250 ? uxSearchMerchandisingText.Text.Substring(0, 249) : uxSearchMerchandisingText.Text);

                        promo.merchandisingTextPdp = (uxPdpShipPromoText.GetPDPMerchandisingHTML(shipMethodId).Length > 500 ? uxPdpShipPromoText.GetPDPMerchandisingHTML(shipMethodId).Substring(0, 499) : uxPdpShipPromoText.GetPDPMerchandisingHTML(shipMethodId));

                        promo.comments = comments;
                        promo.shipMethodId = Convert.ToInt32(shipMethodId);
                        promo.shipMethodName = shipMethodName;
                        promo.fullOrderOrExactPromo = fullOrderOrExactPromo; 
                        promo.stores = stores;
                        promo.dollarMin = (dollarMin.Equals("") ? 0 : Convert.ToDouble(dollarMin));
                        promo.dollarMax = (dollarMax.Equals("") ? 0 : Convert.ToDouble(dollarMax));
                        promo.weightMin = (weightMin.Equals("") ? 0 : Convert.ToDouble(weightMin));
                        promo.weightMax = (weightMax.Equals("") ? 0 : Convert.ToDouble(weightMax));
                        promo.increasePercent = (increasePercent.Equals("") ? 0 : Convert.ToDouble(increasePercent)); ;
                        promo.increaseDollar = (increaseDollar.Equals("") ? 0 : Convert.ToDouble(increaseDollar));
                        promo.increaseWeightThreshold = increaseWeightThreshold;
                        promo.increaseDollarThreshold = increaseDollarThreshold;
                        promo.promoExtras = promoQualifiers;
                        promo.excludeCategoryCodes = excludeCategoryCodes;
                        promo.excludeManufacturers = excludeManufacturers;
                        promo.excludeSkus = excludeSkus;
                        promo.excludePayMethodIds = excludePayMethodIds;
                        promo.excludeCompanyIds = excludeCompanyIds;
                        promo.excludeZoneIds = excludeZoneIds;

                        

                        if(chkIsMerchVisible.Checked){
                            promo.IsMerchVisible = 0;
                        }else{
                            promo.IsMerchVisible = 1;
                        }
                        
                        switch (promo.promoTypeId)
                        {
                            case 2: //Categories
                                promo.categoryCodes = promo.promoExtras;
                                break;
                            case 3: //Manufacturers
                                promo.manufacturers = promo.promoExtras;
                                break;
                            case 4: //SKULevel
                                promo.skus = promo.promoExtras;
                                break;
                            case 5: //PaymentMethod
                                promo.payMethodIds = promo.promoExtras;
                                break;
                            default:
                                break;
                        }

                        if (promoID > 0) {
                            PromoManagement.Update(promo);
                        }
                        else {
                            PromoManagement.Insert(promo);
                        }

                    }
                    uxPromoInputs.Visible = false;
                    uxPromoSetupMessage.Visible = true;
                    uxSubmit.Visible = false;
                    uxPromoSetupMessageContent.Text = "Saved.";
                }
                catch (Exception ex)
                {
                    uxPromoInputs.Visible = false;
                    uxPromoSetupMessage.Visible = true;
                    uxPromoSetupMessageContent.Text = "Not saved." +
                        "<br />" + ex.Message + "<br />" + ex.StackTrace;
                }
            }
        }

        private bool isValidated()
        {
            //validate promotype Name
            if (uxPromoTypeName.Value == null || uxPromoTypeName.Value.Trim().Equals(""))
                problemFields.Add("**Promotype Name - is required");

            //validate promotype
            string promoType = uxPromoType.PromoTypeID.ToString();
            if (!"5".Equals(promoType)) //if not payment method
            {
                //dollar min and max
                if (uxPromoType.DollarMin.Trim().Length == 0 || uxPromoType.DollarMax.Trim().Length == 0)
                    problemFields.Add("**[Orders From] and [To] - required.");
                else
                {
                    if (isNumeric(uxPromoType.DollarMin, System.Globalization.NumberStyles.Currency) == false || isNumeric(uxPromoType.DollarMax, System.Globalization.NumberStyles.Currency) == false)
                        problemFields.Add("**[Orders From] and [To] - must be numeric.");
                    else
                        if (Convert.ToDecimal(uxPromoType.DollarMin) >= Convert.ToDecimal(uxPromoType.DollarMax))
                            problemFields.Add("**[Orders From] must be greater than to [Orders To]");
                        else
                        {
                            if (Convert.ToDecimal(uxPromoType.DollarMin) < 0) 
                                problemFields.Add("**[Orders From] minimum value- must be zero.");

                           // if (Convert.ToDecimal(uxPromoType.DollarMax) > 50000) //todo: add 50000 to config
                             //   problemFields.Add("**[Orders To] maximum value- must be 50000.");
                        }
                }

                //weight min and max
                if (uxPromoType.WeightMin.Trim().Length == 0 || uxPromoType.WeightMax.Trim().Length == 0)
                    problemFields.Add("**[Weight From] and [To] - required.");
                else
                {
                    if (isNumeric(uxPromoType.WeightMin, System.Globalization.NumberStyles.Float) == false || isNumeric(uxPromoType.WeightMax, System.Globalization.NumberStyles.Float) == false)
                        problemFields.Add("**[Weight From] and [To] - must be numeric.");
                    else
                        if (Convert.ToDecimal(uxPromoType.WeightMin) >= Convert.ToDecimal(uxPromoType.WeightMax))
                            problemFields.Add("**[Weight From] must be greater than to [Weight To]");
                        else
                        {
                            if (Convert.ToDecimal(uxPromoType.WeightMin) < 0)
                                problemFields.Add("**[Weight From] minimum value- must be zero.");

                          //  if (Convert.ToDecimal(uxPromoType.WeightMax) > 200) //todo: add 200 to config
                           //     problemFields.Add("**[Weight To] maximum value- must be 200.");
                        }

                }
            }
            else if ("4".Equals(promoType)) //4:skulevel 
            {
                if (isNumeric(uxPromoType.Qualifiers.Replace("\r\n", "").Replace(",", ""), System.Globalization.NumberStyles.Integer) == false)
                    problemFields.Add("**Sku- must be numeric.");

                String[] skus = uxPromoType.Qualifiers.Split(',');
                foreach (String sku in skus)
                {
                    if (sku.Length > 7 || sku.Length < 5)
                    {
                        problemFields.Add("**Sku- length must be 5 to 7");
                        break;
                    }
                }
            }
            
            if ("2".Equals(promoType)) //if categories
            {
                if (uxPromoType.CategoryCodes.Length == 0 || uxPromoType.CategoryCodes.Equals("0"))
                    problemFields.Add("**Category code - must be selected.");
            }

            if ("3".Equals(promoType))//if manufacturers
            {
                if (uxPromoType.Manufacturers.Length == 0 || uxPromoType.Manufacturers.Equals("0"))
                    problemFields.Add("**Manufacturer/s - must be selected.");
            }

            if ("5".Equals(promoType))//if payment method
            {
                if (uxPromoType.PaymentMethods.Length == 0 || uxPromoType.PaymentMethods.Equals("0"))
                    problemFields.Add("**Payment method/s - must be selected.");
            }


            if ("6".Equals(promoType))
            {
                if (uxPromoType.isIncreasePercent == true)
                {
                    if (isNumeric(uxPromoType.IncreasePercent, System.Globalization.NumberStyles.Float) == false || (uxPromoType.IncreasePercent.Length < 1) || (Convert.ToDouble(uxPromoType.IncreasePercent) < 0)) //if increasefreight
                        problemFields.Add("**Increase Percent- must be numeric and greater than zero.");
                }
                else
                {
                    if (isNumeric(uxPromoType.IncreaseDollar, System.Globalization.NumberStyles.Float) == false || (uxPromoType.IncreaseDollar.Length < 1) || (Convert.ToDouble(uxPromoType.IncreaseDollar) < 0)) //if increasefreight
                        problemFields.Add("**Increase Dollar- must be numeric and greater than zero.");
                }


                if (uxPromoType.IncreaseDollarThreshold.ToString().Length < 1 || uxPromoType.IncreaseDollarThreshold.ToString().Equals("0"))
                    problemFields.Add("**Threshold Dollar - is required and greater than zero.");

                if (uxPromoType.IncreaseWeightThreshold.ToString().Length < 1 || uxPromoType.IncreaseWeightThreshold.ToString().Equals("0"))
                    problemFields.Add("**Threshold Weight - is required and greater than zero.");
                else
                {
                    if (isNumeric(uxPromoType.IncreaseDollarThreshold.ToString(), System.Globalization.NumberStyles.Integer) == false)
                        problemFields.Add("**Threshold Dollar - must be numeric.");

                    if (isNumeric(uxPromoType.IncreaseWeightThreshold.ToString(), System.Globalization.NumberStyles.Integer) == false)
                        problemFields.Add("**Threshold Weight - must be numeric.");
                }
            }
            //validate stores
            string stores = GetSelectedItems(uxStore.Items);
            if (stores.Length < 1)
                problemFields.Add("**Store/s- must be checked.");

            //validate discountType
            string discountTypeID = uxPromoType.DiscountTypeID.ToString();
            if (discountTypeID.Equals("0") && !"6".Equals(promoType))
                problemFields.Add("**Discount Type- must be selected.");

            if (!discountTypeID.Equals("5")) //if not none
            {
            if ((isNumeric(uxPromoType.DiscountValue.ToString(), System.Globalization.NumberStyles.Currency) == false && !"1".Equals(discountTypeID) && !"0".Equals(discountTypeID) && !"6".Equals(promoType)) ||
                (uxPromoType.DiscountValue.ToString().Length < 1 && !"1".Equals(discountTypeID) && !"0".Equals(discountTypeID) && !"6".Equals(promoType)) ||
                    (isNumeric(uxPromoType.DiscountValue.ToString(), System.Globalization.NumberStyles.Currency) == false) && !"1".Equals(discountTypeID) && !"0".Equals(discountTypeID) && !"6".Equals(promoType) ||
                (!discountTypeID.Equals("0") && !discountTypeID.Equals("1") && !"6".Equals(promoType) && Convert.ToInt32(uxPromoType.DiscountValue) <= 0))
                problemFields.Add("**Discount value- must be numeric.");
            }

            //validate duration
            DateTime startDate = DateTime.Today; ;
            if (IsDate(uxDuration.StartDate) == false || uxDuration.StartDate == null || uxDuration.StartDate.Equals(""))
                problemFields.Add("**Start date- check format (mm/dd/yyyy).");

            DateTime endDate = DateTime.Today;
            if (IsDate(uxDuration.EndDate) == false || uxDuration.EndDate == null || uxDuration.EndDate.Equals(""))
                problemFields.Add("**End date- check format (mm/dd/yyyy).");

            if (IsDate(uxDuration.StartDate) == true && IsDate(uxDuration.EndDate) == true)
            {
                startDate = Convert.ToDateTime(uxDuration.StartDate + " " + uxDuration.StartTime);
                endDate = Convert.ToDateTime(uxDuration.EndDate + " " + uxDuration.EndTime);

                int result = DateTime.Compare(startDate, endDate);
                if (result > 0)
                    problemFields.Add("**Start and End date - invalid date range.");

                result = DateTime.Compare(DateTime.Now, endDate);
                if (result > 0)
                    problemFields.Add("**End date - invalid.");
            }

            //validate shipping methods
            List<KeyValuePair<string, string>> shipMethod = uxShipMethod.Items;
            if (shipMethod.Count < 1)
                problemFields.Add("**Shipping methods- must be selected.");

            //validate merchandising texts
            if (uxCheckoutMerchandisingText.Text.Length > 500)
                problemFields.Add("**Checkout Merchandising Text length must be less than or equal to 500.");
            if (uxSearchMerchandisingText.Text.Length > 250)
                problemFields.Add("**Search Merchandising Text length must be less than or equal to 250.");
            if (uxPdpMerchandisingText.Text.Length > 500)
                problemFields.Add("**Pdp Merchandising Text length must be less than or equal to 500.");

            if (problemFields.Count > 0)
                return false;
            else
                return true;

        }

        private bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        private static bool IsDate(string sDate)
        {
            DateTime dt;
            bool isDate = true;

            try
            {
                dt = DateTime.Parse(sDate);
            }
            catch
            {
                isDate = false;
            }

            return isDate;
        }

        private string GetSelectedItems(ListItemCollection l)
        {
            List<string> items = new List<string>();
            foreach (ListItem i in l)
            {
                if (i.Selected)
                {
                    items.Add(i.Value);
                }
            }
            return String.Join(",", items.ToArray());
        }

    }

}
