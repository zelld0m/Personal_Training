using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    
    public partial class RegisterForm : System.Web.UI.Page
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

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_Tb_Name.Text) || String.IsNullOrWhiteSpace(_Tb_AuthorityName.Text) || String.IsNullOrWhiteSpace(DropDownList1.SelectedValue))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Required Box IS EMPTY  " + "');", true);
            }
            else
            {
                svc.insertAuthority(_Tb_AuthorityName.Text, Convert.ToInt32(DropDownList1.SelectedValue));
                svc.addDummy(_Tb_Name.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Registration Saved" + "');", true);
                ClearControls();
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);

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

    }
}