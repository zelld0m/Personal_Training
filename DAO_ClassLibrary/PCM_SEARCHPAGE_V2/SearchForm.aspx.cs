using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCM_SEARCHPAGE_V2
{
    public partial class SearchForm : System.Web.UI.Page
    {

        Implementation imp = new Implementation();
        
        #region Function
        protected void Page_Load(object sender, EventArgs e)            // PAGELOAD
        {

            if (!IsPostBack)
            {
                imp.getGLOBALBrand(rdbtnlst_Brand);

            }
            lnkbtn_ClearFilter.Visible = false;
        }
        protected void lnbtn_Search_Click(object sender, EventArgs e)           // BTN SEARCH
        {
            if (IsPostBack)
            {
                imp.searchButton(txt_Search.Text, rdbtnlst_Brand, PlaceHolder1, lbl_NumFound, lbl_PageNumber, lbl_Min, lbl_MAX, drpdwnlst_View);
                lbl_KeyWordSearch.Text = txt_Search.Text;
            }
        }
        protected void lnkbtn_ClearFilter_Click(object sender, EventArgs e)         //  CLEAR FILTER
        {
            if (IsPostBack)
            {
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
            if (IsPostBack)
            {
                imp.dropdownList_NumViews(drpdwnlst_View);
                refresh();
            }

        }
        protected void btn_PageNext_Click(object sender, EventArgs e)   // PAGE >>  
        {
            imp.nextPage(lbl_PageNumber, drpdwnlst_View, lbl_KeyWordSearch, Convert.ToInt32(lbl_NumFound.Text));
            refresh();
        }
        protected void Btn_PagePrevious_Click(object sender, EventArgs e)  // << PAGE
        {
            imp.previousPage(lbl_PageNumber, drpdwnlst_View);
            refresh();
        }
        protected void refresh()    // REFRESH
        {
            if (lbl_KeyWordSearch.Text == "None")
            { }
            else
            {
                if (IsPostBack)
                {
                    imp.refresh(PlaceHolder1, rdbtnlst_Brand, lbl_KeyWordSearch.Text, drpdwnlst_View, Convert.ToInt16(lbl_PageNumber.Text), lbl_Min, lbl_MAX);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)            //TEST REFRESH
        {
            refresh();
        }
        protected void txt_Search_TextChanged(object sender, EventArgs e)  // only if entered   but it works if you type
        {
            //lnbtn_Search_Click(sender, e);
        } 
        #endregion
    }
}