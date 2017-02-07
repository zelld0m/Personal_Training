using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipR.Entities;

namespace Shipr.lib
{
	public partial class ShipMethodSelector : System.Web.UI.UserControl
	{
		public List<Shipping> Source { get; set; }
        public Shipping SelectedShipping { get; set; }
		public List<KeyValuePair<string, string>> Items { get; set; }
		public string Title { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			uxList.DataSource = Source;
			uxList.DataValueField = "Code";
			uxList.DataTextField = "Display";
			uxList.DataBind();
			Items = GetSelectedItems();
			uxTitle.Text = (Title != null) ? Title : "Shipping method";

            if (SelectedShipping != null)
            {
                uxList.SelectedValue = Convert.ToString(SelectedShipping.Code);
            }
		}

		private List<KeyValuePair<string, string>> GetSelectedItems()
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (ListItem i in uxList.Items)
			{
				if (i.Selected)
				{
					list.Add(new KeyValuePair<string,string>(i.Value, i.Text));
				}
			}
			return list;
		}
	}
}