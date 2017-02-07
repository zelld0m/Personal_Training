using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;

namespace SHIPR.ShipR.Project.Controls
{
    public partial class ShipPromoText : System.Web.UI.UserControl
    {
        public string Title { get; set; }             
        private string _value = "";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            uxTitle.Text = (Title != null) ? Title : "Title not set.";

            if (_value != null && _value.Trim().Length > 0)
            {
                if (_value.Contains("<!--|-->"))
                {           
         
                    String[] splitValue = _value.Split(new string[]{"<!--|-->"},StringSplitOptions.None);
                    String boldtext = "";
                    String normaltext = "";

                    try
                    {
                        switch (splitValue.Length)
                        {                            
                            case 1:                                
                                normaltext = splitValue[0];
                                break;  
                            case 2:
                                boldtext = splitValue[1];
                                break;
                            case 3:
                                boldtext = splitValue[1];
                                normaltext = splitValue[2];
                                break;
                        }
                        
                    }
                    catch { 
                    
                    }

                    uxBold.Text = StripTagsRegex(boldtext);
                    uxNormal.Text = normaltext;
                    
                }
                else {
                    uxNormal.Text = _value;
                }
            }
           
        }

        public String GetPDPMerchandisingHTML(String ShippingMethodID) {
            String partSep = "<!--|-->";           
            String link = "<img src=\"" + ConfigurationManager.AppSettings["ImgServer"] + ShippingMethodID + ".png" + "\" />";
            String btext = uxBold.Text;
            String ntext = uxNormal.Text;
            String returnText = "";

            //apply span to bold text other wise none.
            if (btext.Trim() != string.Empty)
                btext = "<span class=\"promoHdrUps\">" + btext + "</span>";

            if (uxBold.Text.Trim() != string.Empty && uxNormal.Text.Trim() != string.Empty) { 
                returnText = link + partSep + btext + partSep + ntext;
            }else if (uxBold.Text.Trim() != string.Empty && uxNormal.Text.Trim() == string.Empty){
                returnText = link + partSep + btext;
            }
            else if (uxBold.Text.Trim() == string.Empty && uxNormal.Text.Trim() != string.Empty){
                returnText = link + partSep + ntext;
            }
            else if(uxBold.Text.Trim() == string.Empty && uxNormal.Text.Trim() == string.Empty){
                returnText = "";
            }

            return link + partSep + btext + partSep + ntext;
        }

        public String GetPDPMerchandisingText() {
            return uxBold.Text + " " + uxNormal;
        }

        public string Value
        {
            set { _value = value; }
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

    }
}