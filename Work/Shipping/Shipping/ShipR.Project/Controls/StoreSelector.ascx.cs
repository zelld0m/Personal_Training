using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipR.Entities;
namespace Shipr.lib
{
	public partial class StoreSelector : System.Web.UI.UserControl
	{
		public List<Store> Source { get; set; }
        public List<Store> SelectedStores{ get; set; }  
		public ListItemCollection Items { get; set; }
		public string Title { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			uxList.DataSource = Source;
            uxList.DataValueField = "StoreID";

            uxList.DataTextField = "StoreName";
			uxList.DataBind();
			Items = uxList.Items;
			uxTitle.Text = (Title != null) ? Title : "Store";

            if (SelectedStores != null)
            {
                foreach (ListItem item in uxList.Items)
                {
                    Store myStoreSelected = SelectedStores.Find(delegate(Store dStore) { return dStore.StoreID == Convert.ToInt32(item.Value); });
                    if (myStoreSelected!=null)
                        uxList.Items.FindByValue(item.Value).Selected = true;
                }
            }
        }
    }
}