using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shipr.lib
{
	public partial class Duration : System.Web.UI.UserControl
	{
		public String StartDate { get; set; }
		public String EndDate { get; set; }
        public String  StartTime { get; set; }
        public String EndTime { get; set; }
		public string Title { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
            
            
           uxTitle.Text = (Title != null) ? Title : "Duration";

            if (StartDate != null && StartDate.Trim().Length > 0)
                uxStartDate.Text = StartDate;
            else
                StartDate = uxStartDate.Text;

            // TEST1 Conversion 

            //(StartDate != null && StartDate.Trim().Length > 0) ? uxStartDate.Text = StartDate : StartDate = uxStartDate.Text;

            if (EndDate!=null && EndDate.Trim().Length > 0)
                uxEndDate.Text = EndDate;
            else
                EndDate = uxEndDate.Text;

            //Test2
           // (EndDate != null && EndDate.Trim().Length > 0) ? uxEndDate.Text = EndDate : EndDate = uxEndDate.Text;



          if (StartTime!=null && StartTime.Trim().Length>0)
             uxStartTime.SelectedIndex = getSelectedIndex(uxStartTime, StartTime);
          else
              StartTime = uxStartTime.SelectedItem.Text;
       
          if (EndTime != null && EndTime.Trim().Length > 0)
              uxEndTime.SelectedIndex = getSelectedIndex(uxEndTime, EndTime);
          else
              EndTime = uxEndTime.SelectedItem.Text;
       
		}

        private int getSelectedIndex(DropDownList ddl, String value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].ToString().Equals(value.PadLeft(8,'0')))
                {
                    return i;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                }
            }
            return 0;
        }
	}
}