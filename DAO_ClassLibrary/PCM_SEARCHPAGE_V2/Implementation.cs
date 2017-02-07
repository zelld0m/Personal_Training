using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PCM_SEARCHPAGE_V2
{
    public class Implementation
    {
        #region APPLICATION 

        Controls_EDP con_EDP = new Controls_EDP();
        Controls_URLSite con_site = new Controls_URLSite();
        Control_Display con_dis = new Control_Display();
        #endregion
        #region Temporary object
        List<String> listBrand = new List<string>();

        #endregion
        #region Functions
        public void radioButton_button(String findBrand, RadioButtonList radiobuttonlist, PlaceHolder PlaceHolder1)
        {
            // con_EDP.BrandSelected_Generate_EDP(findBrand);
            con_dis.SelectedMultipleDisplay2(PlaceHolder1);

            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            listBrand = con_EDP.TempoBrand;
            for (int i = 0; i <= listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
        }
        public void searchButton(string search, RadioButtonList radiobuttonlist, PlaceHolder PlaceHolder1, Label numfound, Label pageNumber, Label lbl_Min, Label lbl_MAX, DropDownList drop)   // useThis as Clear Filter
        {
            #region DisplayProducts

            con_site.Findproduct = search;
            con_EDP.getEDPfromSearchManager2(con_site.SearchManagerURL); //1st  Create an edp using the search textbox this will generate a url for specified search
            con_site.Alldetails_Use_EDP = con_EDP.EdpString;            //2nd  use the generated EdpString
            con_dis.getDetails2(con_site.Alldetails_Use_EDP);           //3rd  get allDetails and store it to the list
            con_dis.SelectedMultipleDisplay2(PlaceHolder1);             //4th  apply Display
            numfound.Text = con_EDP.NumfoundFromSearch.ToString();
            #endregion
            #region DisplayBrand

            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            listBrand = con_dis.Manufacturer;
            listBrand = listBrand.Distinct().ToList();
            listBrand = listBrand.OrderBy(i => i).ToList();             // MAKE brand alphabetical

            for (int i = 0; i < listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
            #endregion
            #region RESET

            int min = 1; // numbering  start 
            int max = 10;      // numbering to end 
            lbl_Min.Text = "" + min;
            lbl_MAX.Text = "" + max;
            numfound.Text = con_EDP.NumfoundFromSearch.ToString();
            con_site.StartRead = 0;
            con_site.ProductLimitView = 10;
            drop.Text = con_site.ProductLimitView.ToString();
            pageNumber.Text = "" + 0;       // --------------------     TEST ------------------
            #endregion
        }
        public void dropdownList_NumViews(DropDownList drop)  // Perfect
        {
            con_site.ProductLimitView = Convert.ToInt32(drop.SelectedValue);           // increase view

        }
        public void nextPage(Label lbl_PageNumber, DropDownList drpdwnlst_View,Label lbl_KeyWordSearch,int numFound)
        {
            //-----
           int  pagenumber = Convert.ToInt32(lbl_PageNumber.Text);
            int x = Convert.ToInt32(drpdwnlst_View.SelectedValue);   // getting the dropdownlist VALUE 
            

            int maxproductview = pagenumber * x;                    //  list value * page
            if (lbl_KeyWordSearch.Text == "None")
            {
            }
            else
            {
                #region postback or REfresh
                if (maxproductview < numFound)
                {

                     pagenumber = Convert.ToInt32(lbl_PageNumber.Text) + 1;   // getting old page # 
                    lbl_PageNumber.Text = "" + pagenumber;

                }
                #endregion
            }
        
        }
        public void previousPage(Label lbl_PageNumber, DropDownList drpdwnlst_View)
        {
            if (Convert.ToInt32( lbl_PageNumber.Text )<= 0)
            {
            }
            else
            {
                int pagenumber = Convert.ToInt32(lbl_PageNumber.Text) - 1;   // getting old page # 
                lbl_PageNumber.Text = "" + pagenumber;
            }

        }
        public void refresh(PlaceHolder placeholder1, RadioButtonList radiobuttonlist, string currentTextboxSearch ,DropDownList numberOfViews , int pageNumber, Label lbl_Min, Label lbl_MAX)
        {
            
            #region Display
            int min = Convert.ToInt32(numberOfViews.SelectedValue) * pageNumber;   // numbering  start 
            int max = Convert.ToInt32(numberOfViews.SelectedValue) + min;          // numbering to end 
            lbl_Min.Text = "" + (min+1);                                           //Label min +1 to make it  count 1,11,21,31
            lbl_MAX.Text = "" + max;

            #region urlSite_SETUP

            con_site.Findproduct = currentTextboxSearch;                                        // product search   = q
            con_site.ProductLimitView = Convert.ToInt32(numberOfViews.SelectedValue);           // ROW 
            con_site.StartRead = (Convert.ToInt32(numberOfViews.SelectedValue) * pageNumber);   // start
            con_EDP.getEDPfromSearchManager2(con_site.SearchManagerURL);                        //Using Url to get EDP
            con_site.Alldetails_Use_EDP = con_EDP.EdpString;                                    //Insert EDP on main site 
            con_dis.getDetails2(con_site.Alldetails_Use_EDP);                                   // Use  Detail Url
            con_dis.SelectedMultipleDisplay2(placeholder1);                                     // Display product On placeholder

            #endregion
         
            #region DisplayBrand

            radiobuttonlist.ClearSelection();                                                    // Clear Selection
            radiobuttonlist.Controls.Clear();                                                    // Clear control
            radiobuttonlist.Items.Clear();                                                       // clear items
            listBrand = con_dis.Manufacturer;                                                    // getlist from Control_display class
            listBrand = listBrand.Distinct().ToList();                                           // distinct listbrand
            listBrand = listBrand.OrderBy(i => i).ToList();                                      // Sort listbrand alphabetical

            for (int i = 0; i < listBrand.Count; i++)                                           //Implement Listbrand on radioButtonlist
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
            #endregion
            #endregion
        }
        public void getGLOBALBrand(RadioButtonList radiobuttonlist)
        {
           con_site.Findproduct = "laptop";
           con_EDP.AllBrand2(con_site.SearchManagerURL);  //1st  Create an edp using the search textbox this will generate a url for specified search

            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            for (int i = 0; i < con_EDP.FullBrand.Count; i++) // FullBrand is the Brandlist from Searchmanager,Brandcount is the #
            {
                listBrand.Add( con_EDP.FullBrand [i]+ " (" + con_EDP.BrandCount[i]+")");
            }
            listBrand = listBrand.Distinct().ToList();              // DISTINCT
            listBrand = listBrand.OrderBy(i => i).ToList();        // MAKE brand alphabetical

            for (int i = 0; i < listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
          
        }
        #endregion
    }
}