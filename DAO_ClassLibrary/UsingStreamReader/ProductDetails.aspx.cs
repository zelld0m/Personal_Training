using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace UsingStreamReader
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        static String search = ""; 
        List<String> searchHistory = new List<string>(); 
        static List<String> listBrand = new List<string>();
        Controls_EDP con_EDP = new Controls_EDP();
       Implementation imp = new Implementation();
        protected void Page_Load(object sender, EventArgs e)
         
        {
           
          
           // Controls_EDP.getEDPfromSearchManager();// working 
          //  Controls_EDP.SearchFiltering_EDP("lenovo"); //  working
          //  Controls_URL cURL = new Controls_URL();
           // cURL.changeFind("Cat");
          

            // Working new Controls
            sample.SaveALLEDP();
            #region postback
            if (!IsPostBack)
            {
                sample.SearchmultipleDisplay("a", PlaceHolder1, listBrand);
                rdbtnlst_Brand.ClearSelection();
                rdbtnlst_Brand.Controls.Clear();
                rdbtnlst_Brand.Items.Clear();
                NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCountALL());
                for (int i = 0; i < listBrand.Count; i++)
                {
                    rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
                }
                rdbtnlst_Brand.AutoPostBack = true;
            }
            //---------------------------- enter on  SEARCH ---------------------------
          //        User textbox as Button when enter is pressed 
            //----------------------------------------------------------------------------------------
            //ListBrand.Clear();
            #endregion
        }

        public  void BtnALL_Click(object sender, EventArgs e)
        {
            sample.SearchmultipleDisplay("a", PlaceHolder1, listBrand);
            NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCountALL());
            #region postback
            if (IsPostBack)
            {
                rdbtnlst_Brand.ClearSelection();
                rdbtnlst_Brand.Controls.Clear();
                rdbtnlst_Brand.Items.Clear();
                for (int i = 0; i < listBrand.Count; i++)
                {
                    rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
                }
                rdbtnlst_Brand.AutoPostBack = true;
            }
            #endregion
            listBrand.Clear();
            TB_Search.Text = string.Empty;
            rdbtnlst_Brand.ClearSelection();
        }
        protected void rdbtnlst_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TEST//
            if (IsPostBack)
            {
                imp.radioButton_button(rdbtnlst_Brand.Text, rdbtnlst_Brand, PlaceHolder1);
            }
            NumberFound.Text = con_EDP.getNumfound().ToString();


            //-------------
            //sample.brandmultipleDisplay(rdbtnlst_Brand.Text, PlaceHolder1 , listBrand);
            //NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCount_Brand());
            // if (IsPostBack)
            //{
            //    rdbtnlst_Brand.ClearSelection();
            //    rdbtnlst_Brand.Controls.Clear();
            //    rdbtnlst_Brand.Items.Clear();
            //    for (int i = 0; i < listBrand.Count; i++)
            //    {
            //        rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
            //    }
            //    rdbtnlst_Brand.AutoPostBack = true;
            //}
            //listBrand.Clear();

        }

      

        protected void TB_Search_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            searchHistory.Add(TB_Search.Text);
                sample.SearchmultipleDisplay(TB_Search.Text, PlaceHolder1, listBrand);
                #region postback
                if (IsPostBack)
                {
                    rdbtnlst_Brand.ClearSelection();
                    rdbtnlst_Brand.Controls.Clear();
                    rdbtnlst_Brand.Items.Clear();
                    for (int i = 0; i < listBrand.Count; i++)
                    {
                        rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
                    }
                    rdbtnlst_Brand.AutoPostBack = true;
                }
            search = TB_Search.Text;
            #endregion
            listBrand.Clear();
            rdbtnlst_Brand.ClearSelection();
            NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCount_Search());
          
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //--------TEST ------DROPDOWNLISt-----------
            imp.dropdownList_NumViews(DropDownList1);
            Button3_Click(sender, e);       // Success searchbutton

            //-------------------------
            //sample.ProductSize_dropdownList_control(DropDownList1);
            #region postback

            //sample.SearchmultipleDisplay("a", PlaceHolder1, listBrand);
            //NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCountALL());
            //if (IsPostBack)
            //{
            //    rdbtnlst_Brand.ClearSelection();
            //    rdbtnlst_Brand.Controls.Clear();
            //    rdbtnlst_Brand.Items.Clear();
            //    for (int i = 0; i < listBrand.Count; i++)
            //    {
            //        rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
            //    }
            //    rdbtnlst_Brand.AutoPostBack = true;
            //}
            //listBrand.Clear();
            //TB_Search.Text = string.Empty;
            //rdbtnlst_Brand.ClearSelection();
            #endregion
        }

        protected void Button2_Click(object sender, EventArgs e)  // FIXING CLEAR SELECTION 
        {
            // -- TEST -----------CLEAR BRAND FILTER ---------------


            //0---------------------------------------------


            if (search.Equals(String.Empty) || search == "")
            {
                sample.SearchmultipleDisplay("a", PlaceHolder1, listBrand);
            }
            else
            {
                sample.SearchmultipleDisplay(search, PlaceHolder1, listBrand);
            }
            NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCount_Search());
            if (IsPostBack)
            {
                rdbtnlst_Brand.ClearSelection();
                rdbtnlst_Brand.Controls.Clear();
                rdbtnlst_Brand.Items.Clear();
                for (int i = 0; i < listBrand.Count; i++)
                {
                    rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
                }
                rdbtnlst_Brand.AutoPostBack = true;
            }
            listBrand.Clear();
            rdbtnlst_Brand.ClearSelection();
            rdbtnlst_Brand.ClearSelection();
        }


        #region TEST new 
        protected void Button3_Click(object sender, EventArgs e)/// SEARCH BUTTON
        {
            if (IsPostBack)
            {
                imp.searchButton(TB_Search.Text, rdbtnlst_Brand, PlaceHolder1);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)   /// CLEAR FILTER
        {
            if (IsPostBack)
            {
                Button3_Click(sender,e);
                rdbtnlst_Brand.ClearSelection();
            }
        }
        #endregion 
    }
}
