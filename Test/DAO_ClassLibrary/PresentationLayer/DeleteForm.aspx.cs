using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class DeleteForm : System.Web.UI.Page
    {
        int Id;
        String Name;
        int AccessLevel;
        String AuthorityName;
        ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(Request.QueryString["id"]);
            Name = Convert.ToString(Request.QueryString["Name"]);
            AccessLevel = Convert.ToInt32(Request.QueryString["AccessLevel"]);
            AuthorityName = Convert.ToString(Request.QueryString["AuthorityName"]);

            Lbl_AccessLevel.Text = AccessLevel.ToString();
            Lbl_AuthorityName.Text = AuthorityName.ToString();
            Lbl_Id.Text = Id.ToString();
            Lbl_name.Text = Name.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_Tb_ID.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ID BOX IS EMPTY  " + "');", true);
                refresh();
            }
            else
            {

                _BtnSearch_Click(sender, e); // using search for validation of records if Available
                if (GridView1.Rows.Count > 0 && GridView2.Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " Deleted " + "');", true);
                    svc.deleteDummy(Convert.ToInt32(_Tb_ID.Text));
                    svc.deleteAuthority(Convert.ToInt32(_Tb_ID.Text));
                    ClearControls();
                    refresh();
                }
                else if (GridView1.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " NO ID FOUND " + "');", true);
                }
                refresh();
            }


        }
        #region Extra
        protected void _BtnSearch_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(_Tb_ID.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "id box is empty To search " + "');", true);
                refresh();
            }
            else
            {
                GridView2.DataSource = svc.searchAuthority(Convert.ToInt32(_Tb_ID.Text));
                GridView2.DataBind();
                GridView1.DataSource = svc.SearchDummy(Convert.ToInt32(_Tb_ID.Text));
                GridView1.DataBind();
            }
        }
        void refresh()
        {
            GridView1.DataSource = svc.viewALLDummy();
            GridView1.DataBind();
            GridView2.DataSource = svc.viewAuthority();
            GridView2.DataBind();
        }
    
        private void ClearControls()
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Text = string.Empty;
                    }
                }
            }
        }
        #endregion Extra
    }
}