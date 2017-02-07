using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    

    public partial class UpdateForm : System.Web.UI.Page
    {
        ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
        int Id;
        String Name;
        int AccessLevel;
        String AuthorityName;
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

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            ClearControls();
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

        protected void _BtnUpdate_Click(object sender, EventArgs e)
        {
            _BtnSearch_Click(sender, e);   // Activate Button Search
            if (String.IsNullOrWhiteSpace(_Tb_ID.Text) || String.IsNullOrWhiteSpace(_Tb_Name.Text) || String.IsNullOrWhiteSpace(_Tb_AuthorityName.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ID BOX IS EMPTY  " + "');", true);
             
            }

            else
            {
                _BtnSearch_Click(sender, e);  // using search for validation of records if Available
                if (GridView1.Rows.Count > 0 && GridView2.Rows.Count > 0)
                {
                    svc.UpdateDummy(Convert.ToInt32(_Tb_ID.Text), _Tb_Name.Text);
                    svc.UpdateAuthority(Convert.ToInt32(_Tb_ID.Text), Convert.ToInt32(DropDownList1.SelectedValue), _Tb_AuthorityName.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " UPDATE SUCCESSFUL " + "');", true);
              

                }
                else if (GridView1.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " NO ID FOUND " + "');", true);
                }
                
                GridView1.Dispose();
                GridView2.Dispose();
            }
            ClearControls();
        }
        protected void _BtnSearch_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(_Tb_ID.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "id box is empty To search " + "');", true);
              
            }

            else
            {
                GridView2.DataSource = svc.searchAuthority(Convert.ToInt32(_Tb_ID.Text));
                GridView2.DataBind();
                GridView1.DataSource = svc.SearchDummy(Convert.ToInt32(_Tb_ID.Text));
                GridView1.DataBind();

            }
        }
        void refresh(){
            GridView1.DataSource = svc.viewALLDummy();
            GridView1.DataBind();
            GridView2.DataSource = svc.viewAuthority();
            GridView2.DataBind();
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
    }
}