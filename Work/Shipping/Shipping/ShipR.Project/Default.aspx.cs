using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Shipr
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			HtmlGenericControl body = (HtmlGenericControl)this.Page.Master.FindControl("body");
			body.Attributes.Add("class", "home");
		}
	}
}
