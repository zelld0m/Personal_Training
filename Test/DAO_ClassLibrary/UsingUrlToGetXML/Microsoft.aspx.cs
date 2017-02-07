using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsingUrlToGetXML
{
    public partial class Microsoft : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // Lbl_Data1.Text= MicrosoftLink.downloadStringFromUrl("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0");
        }
        protected void Btn_Find_Click(object sender, EventArgs e) // find 1
        {
            Lbl_Find.Text= MicrosoftLink.findReaderValue();
        }
        

        protected void Btn_Fill1_Click(object sender, EventArgs e)  // fill 1
        {
            Lbl_Data1.Text = MicrosoftLink.microsoftTutorial(15);
        }

        protected void Btn_Fill2_Click(object sender, EventArgs e)  // fill 2
        {
            Lbl_Data2.Text = MicrosoftLink.microsoftTutorial2(16);
        }

        protected void Button1_Click(object sender, EventArgs e)    //CreateXML BTN
        {
            MicrosoftLink.creatingXMLUsingString();
        }

        protected void Button2_Click(object sender, EventArgs e)    // find 2
        {
            TextBox2.Text = MicrosoftLink.findReaderValue2();  // no value returned
       //     Lbl_Find.Text = MicrosoftLink.implement(TextBox1,TextBox2);
        }
    }

}