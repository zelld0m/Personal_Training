using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace PresentationLayer
{
    public partial class LoginForm : System.Web.UI.Page
    {

        ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Tb_Name.Text) || String.IsNullOrWhiteSpace(Tb_AuthorityName.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " Please Complete the TextBox " + "');", true);
            }
            else
            {

                GridView1.DataSource = svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text);
                GridView1.DataBind();
               
                    if (GridView1.Rows.Count > 0)//Sucess Login In
                    {
                        int AccessLevel = Convert.ToInt32(svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text).Tables[0].Rows[0][4]);
                        int id = Convert.ToInt32(svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text).Tables[0].Rows[0][0]);
                        String Name = Convert.ToString(svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text).Tables[0].Rows[0][1]);
                        String AuthorityName = Convert.ToString(svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text).Tables[0].Rows[0][3]);
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", " : alert('" + " Congratulations ::" + AccessLevel + "');", true);
                        Response.Write("<script>alert('Congrats PASSWORD AND USERNAME: AccessLevel = " + AccessLevel + " ');</script>");
                        Response.Redirect("MainMenuForm.aspx?id=" + id + "&AccessLevel=" + AccessLevel + "&AuthorityName=" + AuthorityName + "&Name=" + Name + "", true);// Correct 


                    }
                
             
                
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " Input Error " + "');", true);
                }
            }
        }

        protected void Btn_Out_Click(object sender, EventArgs e)
        {
            GridView1.DataSource= svc.Validation(Tb_Name.Text, Tb_AuthorityName.Text);
            GridView1.DataBind();
        }
    }
}