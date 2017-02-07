using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Shipr.lib
{
	public partial class MultilineText : System.Web.UI.UserControl
	{
		public string Title { get; set; }
		public string Text { get; set; }
        public string Value { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{			
			uxTitle.Text = (Title != null) ? Title : "Title not set.";

            if (Value != null && Value.Trim().Length > 0)
            {
                uxInput.Text = StripTagsRegex(Value);
            }
            else
            {
                Text = uxInput.Text;
            }
		}

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public String GetHtml()
        {
            String text = uxInput.Text;

            if (text.Trim() != string.Empty)
                text = "<strong>" + text + "</strong>";

            return text;
        }
    
    }
}