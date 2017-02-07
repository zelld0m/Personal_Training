using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PresentationLayer.ServiceReference1;
namespace PresentationLayer
{
    public partial class Admin : System.Web.UI.Page
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

            refresh();
        }
        void refresh()
        {
            GridView1.DataSource = svc.viewALLDummy();
            GridView1.DataBind();
            GridView2.DataSource = svc.viewAuthority();
            GridView2.DataBind();

        }
        #region Buttons
        protected void _BtnAdd_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(_Tb_Name.Text) || String.IsNullOrWhiteSpace(_Tb_AuthorityName.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Required Box IS EMPTY  " + "');", true);
                refresh();


            }
            else
            {
                svc.insertAuthority(_Tb_AuthorityName.Text, Convert.ToInt32(DropDownList1.SelectedValue));
                svc.addDummy(_Tb_Name.Text);
                ClearControls();
                refresh();
            }
        }
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
        protected void _BtnUpdate_Click(object sender, EventArgs e)
        {
            _BtnSearch_Click(sender, e);   // Activate Button Search
            if (String.IsNullOrWhiteSpace(_Tb_ID.Text) || String.IsNullOrWhiteSpace(_Tb_Name.Text) || String.IsNullOrWhiteSpace(_Tb_AuthorityName.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ID BOX IS EMPTY  " + "');", true);
                refresh();
            }

            else
            {
                _BtnSearch_Click(sender, e);  // using search for validation of records if Available
                if (GridView1.Rows.Count > 0 && GridView2.Rows.Count > 0)
                {
                    svc.UpdateDummy(Convert.ToInt32(_Tb_ID.Text), _Tb_Name.Text);
                    svc.UpdateAuthority(Convert.ToInt32(_Tb_ID.Text), Convert.ToInt32(DropDownList1.SelectedValue), _Tb_AuthorityName.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " UPDATE SUCCESSFUL " + "');", true);
                    refresh();

                }
                else if (GridView1.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " NO ID FOUND " + "');", true);
                }
                refresh();
            }
            ClearControls();
        }
        protected void _btnDelete_Click(object sender, EventArgs e)
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
                    refresh();
                    ClearControls();
                }
                else if (GridView1.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " NO ID FOUND " + "');", true);
                }
                refresh();
            }
        }
        #endregion buttons
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Btn_AuthorityName_Click(object sender, EventArgs e) // Refresh Button
        {
            refresh();

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
        protected void Btn_Admin_Click(object sender, EventArgs e)
        {

        }
        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }
        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            String status = String.Empty;
            // PresentationLayer proxy = new ;
        }
    }
}