using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class SearchForm : System.Web.UI.Page
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
        
        private void Clear(RadioButton rb)
        {
            if (rb.Checked)
            {
                rb.Checked = false;
            }
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuForm.aspx?id=" + Id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);

        }
        #region Button

        protected void rb_1_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = svc.SearchBrand(rb_1.Text);
            GridView1.DataBind();
        }
        protected void rb_2_CheckedChanged(object sender, EventArgs e)
        {
                GridView1.DataSource = svc.SearchBrand(rb_2.Text);
                GridView1.DataBind();
        }

        protected void rb_3_CheckedChanged(object sender, EventArgs e)
        {
                GridView1.DataSource = svc.SearchBrand(rb_3.Text);
                GridView1.DataBind();
        }

        protected void rb_4_CheckedChanged(object sender, EventArgs e)
        { 
            GridView1.DataSource = svc.SearchBrand(rb_4.Text);
            GridView1.DataBind();
        }

        protected void rb_5_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = svc.SearchBrand(rb_5.Text);
            GridView1.DataBind();
        }
        protected void rb_ALL_CheckedChanged(object sender, EventArgs e)
        {
         GridView1.DataSource = svc.ViewALLProduct();
            GridView1.DataBind();
        }

        #endregion Button

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
        private void refresh()
        {

            GridView1.DataSource = svc.ViewALLProduct();
            GridView1.DataBind();
        }
    }
}