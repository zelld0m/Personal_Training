using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PCM_SearchPage
{
    public class Implementation
    {
        Controls_EDP con_EDP = new Controls_EDP();
        Controls_URL con_URL = new Controls_URL();
        ControlDisplay con_dis = new ControlDisplay();
        static List<String> listBrand = new List<string>();

        public void radioButton_button(String findBrand, RadioButtonList radiobuttonlist, PlaceHolder PlaceHolder1)
        {
            con_EDP.BrandSelected_Generate_EDP(findBrand);
            con_dis.SelectedMultipleDisplay(con_EDP.getBranded_EDP(), PlaceHolder1);

            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            listBrand = con_EDP.getTempoBrand();
            for (int i = 0; i < listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
        }

        public void searchButton(string search , RadioButtonList radiobuttonlist,PlaceHolder PlaceHolder1 )   // useThis as Clear Filter
        {
                con_URL.Find(search);  // Success
                con_EDP.generateBrandList();
                con_dis.SelectedMultipleDisplay(con_EDP.getAll_EDP(), PlaceHolder1);
                radiobuttonlist.ClearSelection();
                radiobuttonlist.Controls.Clear();
                radiobuttonlist.Items.Clear();
                listBrand = con_EDP.getBrand();
                for (int i = 0; i<listBrand.Count; i++)
                {
                    radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
                }
                radiobuttonlist.AutoPostBack = true;
        }

        public void dropdownList_NumViews(DropDownList drop)
        {
            int x = Convert.ToInt32(drop.SelectedValue);
            con_URL.LimitView(x);
        }


        public void PagingControl(int pageNumber)
        {
            con_URL.ChangePage(pageNumber);
        }
        public void ClearFilter()
        {

        }
        public void Defaultreset()
        {

        }
        public int getNumfound()
        {
            return con_EDP.getNumfound();
        }
        public int getPage()
        {
            return con_URL.getpage();
        }
        public void nextPage(Label lbl_PageNumber, DropDownList drpdwnlst_View, Label lbl_Min, Label lbl_MAX)
        {
            ///----------------------------------------


            int pagenumber = Convert.ToInt32(lbl_PageNumber.Text) + 1;

            int min = Convert.ToInt32(drpdwnlst_View.SelectedValue) * pagenumber;
            int max = Convert.ToInt32(drpdwnlst_View.SelectedValue) + min;
            lbl_Min.Text = "" + min;
            lbl_MAX.Text = "" + max;
            PagingControl(Convert.ToInt32(pagenumber));
            lbl_PageNumber.Text = "" + pagenumber;

        }
        public void previousPage(Label lbl_PageNumber, DropDownList drpdwnlst_View, Label lbl_Min, Label lbl_MAX)
        {
            ///----------------------------------------
            int pagenumber = Convert.ToInt32(lbl_PageNumber.Text);
            if (pagenumber > 0)
            {
                pagenumber = Convert.ToInt32(lbl_PageNumber.Text) - 1;
                int min = Convert.ToInt32(drpdwnlst_View.SelectedValue) * pagenumber;
                int max = Convert.ToInt32(drpdwnlst_View.SelectedValue) + min;
                lbl_Min.Text = "" + min;
                lbl_MAX.Text = "" + max;
                PagingControl(Convert.ToInt32(pagenumber));

                lbl_PageNumber.Text = "" + pagenumber;
            }
        }


    }
}