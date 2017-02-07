using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreatingMultipleItemUsingloop
{
    public partial class MultipleForm : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {

        }
        protected int NumberOfControls
        {
            get { return Convert.ToInt32(Session["noCon"]); }
            set { Session["noCon"] = value.ToString(); }
        }

        private void Page_Init(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
                //Initiate the counter of dynamically added controls
                this.NumberOfControls = 0;
            else
                //Controls must be repeatedly be created on postback
                this.createControls();
        }
       

        protected void btnCreate_Click(object sender, EventArgs e)          // Create's Textbox  // Inside a placeholder-object
        {
            SAMPLE();

            //TextBox tbx = new TextBox();
            //tbx.ID = "txtData" + NumberOfControls;
            //NumberOfControls++;
            //PlaceHolder1.Controls.Add(tbx);
        }               
        protected void btnRead_Click(object sender, EventArgs e)// 
        {
            int count = this.NumberOfControls;

            for (int i = 0; i < count; i++)
            {
                TextBox tx = (TextBox)PlaceHolder1.FindControl("txtData" + i.ToString());  // finds  VALUE LABEL 
                //Add the Controls to the container of your choice
                Label1.Text += tx.Text + ",";  //  implement add value to label
            }
        }

        private void createControls()   // <====================== you just created an object But NO VALUE ======================> 
        {
            int count = this.NumberOfControls;

            for (int i = 0; i < count; i++)  // ------------------- FOCUS HERE  < ------------------
            {
                PlaceHolder ph = new PlaceHolder();
                ph.ID = "placeholder" + i.ToString();
                Label lblname = new Label();
               
                lblname.ID = "labelname" + i.ToString();
                lblname.Text = " ";
                TextBox tx = new TextBox();
                tx.ID = "txtData" + i.ToString();
                //Add the Controls to the container of your choice
                //   <-- Created textbox and inserted in the placeholder ---> 
               // ph.Controls.Add(lblname);
              //  ph.Controls.Add(tx);

                PlaceHolder1.Controls.Add(tx);
               // PlaceHolder1.Controls.Add(ph); // multiple panel inside panel cannot be generatedinside the looop
                // <------- ADDED -------->

                // <------ ADDED END ----->
            }
            
        }



        private void SAMPLE()
        {

            for(int i = 0; i <= 10; i++) { 
            TextBox tbi = new TextBox();
            tbi.ID = "txtData" + i;
            NumberOfControls++;
                PlaceHolder ph = new PlaceHolder();
                ph.ID = "placeholderx" + i.ToString();
                tbi.Text = ":" + i.ToString();
                ph.Controls.Add(tbi);
                PlaceHolder1.Controls.Add(ph);
            }
        }


    }
}