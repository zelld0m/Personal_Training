using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipR.Entities;

namespace Shipr.lib
{
	public partial class SingleTextBox : System.Web.UI.UserControl
	{
		public string Text { get; set; }
		public string Value { get; set; }
		public string Title { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{    
			uxTitle.Text = (Title != null) ? Title : "Name:";
            uxValue.Visible = true;
            uxSingleTextBox.Visible = true;
            if (Value != null && Value.Length>0)
                  uxValue.Text = Value;
            else
                Value = uxValue.Text;

            uxLabel.Text = "Promo Name:";     
     	}	
	}
}