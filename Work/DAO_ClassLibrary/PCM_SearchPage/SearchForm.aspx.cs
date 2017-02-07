using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCM_SearchPage
{
    public partial class SearchForm : System.Web.UI.Page
    {
        Implementation imp = new Implementation();
        int min = 0;
        int max = 0;
        //static int foundProduct = 0;
        static string previewsSearch = "";
        int pagenumber =0 ;
        protected void Page_Load(object sender, EventArgs e)            // PAGELOAD
        {
            if (!IsPostBack)
            { 
            }
            lnkbtn_ClearFilter.Visible = false;
        }

        protected void lnbtn_Search_Click(object sender, EventArgs e)           // BTN SEARCH
        {
            previewsSearch = txt_Search.Text;
            if (IsPostBack)
            {
                imp.PagingControl(0);
                imp.searchButton(txt_Search.Text, rdbtnlst_Brand, PlaceHolder1);
                lbl_PageNumber.Text = ""+imp.getPage();
                lbl_NumFound.Text = "" + imp.getNumfound();
                lbl_KeyWordSearch.Text = txt_Search.Text;
                min = Convert.ToInt32(drpdwnlst_View.SelectedValue) * pagenumber;
                max = Convert.ToInt32(drpdwnlst_View.SelectedValue) + min;
                lbl_Min.Text = "" + min;
                lbl_MAX.Text = "" + max;
            }
        }

        protected void lnkbtn_ClearFilter_Click(object sender, EventArgs e)         //  CLEAR FILTER
        {
            if (IsPostBack)
            {
                rdbtnlst_Brand.ClearSelection();
                refresh();
                rdbtnlst_Brand.ClearSelection();
                lnkbtn_ClearFilter.Visible = false;
            }
        }

        protected void rdbtnlst_Brand_SelectedIndexChanged(object sender, EventArgs e)      //BRAND RADIO BUTTON
        {
            if (IsPostBack)
            {
                imp.radioButton_button(rdbtnlst_Brand.Text, rdbtnlst_Brand, PlaceHolder1);
                lnkbtn_ClearFilter.Visible = true;
            }
        }

        protected void drpdwnlst_View_SelectedIndexChanged(object sender, EventArgs e)   // DROP DOWNLIST # VIEW
        {
            imp.dropdownList_NumViews(drpdwnlst_View);
            refresh();
        }

        protected void btn_PageNext_Click(object sender, EventArgs e)   // PAGE >>  
        {
            pagenumber = Convert.ToInt32(lbl_PageNumber.Text);
            int x = Convert.ToInt32(drpdwnlst_View.SelectedValue);
            int maxproductview = pagenumber * x;
            if (maxproductview < Convert.ToInt32(lbl_MAX.Text))
            {


                if (IsPostBack)
                {
                    imp.nextPage(lbl_PageNumber, drpdwnlst_View, lbl_Min, lbl_MAX);
                    refresh();

                }
            }

        }

        protected void Btn_PagePrevious_Click(object sender, EventArgs e)  // << PAGE
        {
            if (IsPostBack)
            {

                imp.previousPage(lbl_PageNumber, drpdwnlst_View, lbl_Min, lbl_MAX);
                refresh();


            }
        }
        protected void refresh()    // REFRESH
        {
            if (IsPostBack)
            {
                imp.searchButton(previewsSearch, rdbtnlst_Brand, PlaceHolder1);
                lbl_NumFound.Text = "" + imp.getNumfound();
                lbl_KeyWordSearch.Text = txt_Search.Text;
            }
        }



    }
}