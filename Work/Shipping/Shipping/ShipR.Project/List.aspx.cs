using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShipR.Entities;
using ShipR.Business;
using System.Data;

namespace Shipr
{
	public partial class List : System.Web.UI.Page
	{
        public Lookup lookup = PromoManagement.GetGenericLookUp();              // FILLED WITH DATA 
		protected bool _allowedRead;
		protected bool _allowedWrite;

		protected void Page_Load(object sender, EventArgs e)
		{
			UserAccess access = new UserAccess(Request.ServerVariables["LOGON_USER"]);                                      // VALIDATION
			HtmlGenericControl body = (HtmlGenericControl)this.Page.Master.FindControl("body");
			_allowedRead = access.AllowedRead;                                                                              // Setting if page can read and write
			_allowedWrite = access.AllowedWrite;

			body.Attributes.Add("class", "list");
			btnUpdateStatusFalse.Enabled = _allowedWrite;

			if (!IsPostBack)
			{
                gridPromos.DataSource = PromoManagement.GetActivePromos().Tables[0];
                gridPromos.DataBind();
			}

		}

       

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dataTable = (chkShowAll.Checked == false ? PromoManagement.GetActivePromos().Tables[0] : PromoManagement.GetAllPromos().Tables[0]);             
            if (dataTable != null)
                gridPromos.DataSource = dataTable;
            gridPromos.PageIndex = e.NewPageIndex;
            gridPromos.DataBind();
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {         
            DataTable dataTable = (chkShowAll.Checked==false? PromoManagement.GetActivePromos().Tables[0]:PromoManagement.GetAllPromos().Tables[0]);             
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gridPromos.DataSource = dataView;
                gridPromos.DataBind();
            }
        }

        protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            gridPromos.DataSource = (chkShowAll.Checked == false ? PromoManagement.GetActivePromos().Tables[0] : PromoManagement.GetAllPromos().Tables[0]);             
            gridPromos.DataBind();
			if (_allowedWrite)
			{
				btnUpdateStatusTrue.Enabled = (chkShowAll.Checked == false ? false : true);
			}
			else
			{
				btnUpdateStatusTrue.Enabled = _allowedWrite;
			}
        }

        //--------------xxxxxxxxxxx CREATE xxxxxxxxxxxxxxxxxx-------------------
        //protected void ShowInactive(object sender,EventArgs e)
        //{

        //    //Create SP for INACTIVE
        //    //gridPromos.DataSource = PromoManagement.GetAllInactivePromos().Tables[0];
        //    //gridPromos.DataBind();
        //}

        protected void btnUpdateStatusTrue_Click(object sender, EventArgs e)
        {
            updateStatus(true);
        }

        protected void btnUpdateStatusFalse_Click(object sender, EventArgs e)
        {
            updateStatus(false);
        }

        private void updateStatus(Boolean status)
        {
            for (int i = 0; i < gridPromos.Rows.Count; i++)
            {
                GridViewRow row = gridPromos.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {
                    PromoManagement.UpdateStatus(Convert.ToInt32(gridPromos.Rows[i].Cells[2].Text),Convert.ToInt16(status), Request.ServerVariables["LOGON_USER"]);
                }
            }
            DataTable dataTable = (chkShowAll.Checked == false ? PromoManagement.GetActivePromos().Tables[0] : PromoManagement.GetAllPromos().Tables[0]);
            if (dataTable != null)
                gridPromos.DataSource = dataTable;
            gridPromos.DataBind();
        }
	}
}
