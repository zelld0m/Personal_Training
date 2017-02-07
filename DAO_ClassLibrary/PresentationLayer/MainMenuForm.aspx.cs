using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class MainMenuForm : System.Web.UI.Page
    {
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

            admin_config(AccessLevel);

        }
        #region Admin_CONFIG
        void admin_config(int accesslvl)
        {
            switch (accesslvl)
            {
                case 1: Btn_Admin.Visible = false; Btn_Delete.Visible = false; Btn_Registration.Visible = false; Btn_Update.Visible = false; break;
                case 2: Btn_Admin.Visible = false; Btn_Delete.Visible = false; Btn_Registration.Visible = false; break;
                case 3: Btn_Admin.Visible = false; Btn_Delete.Visible = false; Btn_Update.Visible = false; break;
                case 4: Btn_Admin.Visible = false; Btn_Delete.Visible = false; break;
                case 5: break;
            }

        }
        #endregion Admin_CONFIG
        #region BTN
        protected void Btn_Registration_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }
        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchForm2.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }
        protected void Btn_Admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 
        }
        #endregion ENDBTN


    }
}