using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UsingStreamReader
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
                con_URL.changeFind(search);  // Success
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
            con_URL.changeProductLimitView(x);
        }

        public void ClearFilter()
        {

        }
    }
}