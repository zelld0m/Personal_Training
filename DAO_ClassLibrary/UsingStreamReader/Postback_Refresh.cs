using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UsingStreamReader
{
    public class Postback_Refresh
    {

        #region productView

        #endregion

        #region BrandList
        void postbackForPageLoad(PlaceHolder PlaceHolder1, List<string> listBrand, RadioButton rdbtnlst_Brand)
        {
            //if (!IsPostBack)
            //{
            //    sample.SearchmultipleDisplay("a", PlaceHolder1, listBrand);
            //    rdbtnlst_Brand.ClearSelection();
            //    rdbtnlst_Brand.Controls.Clear();
            //    rdbtnlst_Brand.Items.Clear();
            //    NumberFound.Text = "Items Found : " + Convert.ToString(sample.getCountALL());
            //    for (int i = 0; i < listBrand.Count; i++)
            //    {
            //        rdbtnlst_Brand.Items.Add(new ListItem(listBrand[i]));
            //    }
            //    rdbtnlst_Brand.AutoPostBack = true;
            //}
        }

        #endregion
    }
}