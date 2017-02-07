using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipR.Entities;

namespace Shipr.lib
{
	public partial class DiscountType : System.Web.UI.UserControl
	{
		public List<ShipR.Entities.DiscountType> Source { get; set; }
        public ShipR.Entities.DiscountType SelectedDiscount { get; set; }
		public string Type { get; set; }
		public string Text { get; set; }
		public string Value { get; set; }
		public string Title { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (Source != null)
            {
                ShipR.Entities.DiscountType dt = new ShipR.Entities.DiscountType();
                dt.DiscountTypeID = 0;
                dt.DiscountTypeDesc = "-";
                dt.DetailedDesc = "-";
                Source.Insert(0, dt);
                uxType.DataSource = Source;
                uxType.DataValueField = "DiscountTypeID";
                uxType.DataTextField = "DiscountTypeDesc";
                uxType.DataBind();
            }

			uxTitle.Text = (Title != null) ? Title : "Discount type";
            if (SelectedDiscount != null)
            {
                Type = SelectedDiscount.DiscountTypeID.ToString();
                uxType.SelectedValue = SelectedDiscount.DiscountTypeID.ToString();
                if (!"1".Equals(Type) && Type!=null)
                {
                    uxValue.Visible = true;
                    uxExtra.Visible = true;
                    uxValue.Text = Value;
                }
                else
                {
                    uxExtra.Visible = false;
                    uxValue.Visible = false;
                    uxValue.Text = null;
                }
            }
            else
            {
                Type = uxType.SelectedValue;
                Text = uxType.SelectedItem.Text;
                Value = uxValue.Text;
            }
		}

		protected void uxType_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!"1".Equals(Type) && !"0".Equals(Type)) //1:Free and 0:no selected
			{
				uxExtra.Visible = true;
                uxValue.Visible = true;
			}
			else
			{
				uxExtra.Visible = false;
                uxValue.Visible = false;
				uxValue.Text = null;
			}
		}
	}
}