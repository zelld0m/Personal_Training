using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCM_SearchPage
{
    
    public partial class Search : System.Web.UI.Page
    {
        //Controls_EDP con_EDP = new Controls_EDP();
        //Controls_URL con_URL = new Controls_URL();
        //ControlDisplay con_dis = new ControlDisplay();
        Implementation imp = new Implementation();
        static int foundProduct = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foundProduct = imp.getNumfound();
                Lbl_SearchFound.Text = "ProductFound :" + foundProduct;
            }
        }

        protected void Btn_search_Click(object sender, EventArgs e)// search button
        {
            if (IsPostBack)
            {
                imp.searchButton(TB_Search.Text, rdbtnlst_Brand, PlaceHolder1);
              //  Lbl_SearchFound.Text = "ProductFound :" + imp.getNumfound();
            }
        }

        protected void rdbtnlst_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                imp.radioButton_button(rdbtnlst_Brand.Text, rdbtnlst_Brand, PlaceHolder1);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)  // # views 
        {
            imp.dropdownList_NumViews(DropDownList1);
            Btn_search_Click(sender, e);
        }

        protected void BtnClearFilter_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                rdbtnlst_Brand.ClearSelection();
                Btn_search_Click(sender, e);
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) // PAGE # 
        {
            if (IsPostBack)
            {
               imp.PagingControl(Convert.ToInt32 (DropDownList2.SelectedValue));
                Btn_search_Click(sender, e);
            }
        }
    }
}