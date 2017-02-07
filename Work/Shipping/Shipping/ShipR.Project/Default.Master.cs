using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShipR.Business;
using System.Configuration;

namespace Shipr
{
	public partial class Default : System.Web.UI.MasterPage
	{
		public UserAccess Access { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			Access = new UserAccess(Request.ServerVariables["LOGON_USER"]);
			//setup.Visible = access.AllowedWrite;
			if ((Access.AllowedRead || Access.AllowedWrite)||(ConfigurationManager.AppSettings["isDev"].ToString()=="1"))//CRF48287 7/15/2014
			{
				uxAllow.Visible = true;
				uxDeny.Visible = false;
			}
			else
			{
				uxAllow.Visible = false;
				uxDeny.Visible = true;
			}
		}

	}
}
