using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDummy
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void _Btn_Delete_Click(object sender, EventArgs e)
        {
            svc.deletedummy(Convert.ToInt32(_Tb_delete.Text));
        }
    }
}