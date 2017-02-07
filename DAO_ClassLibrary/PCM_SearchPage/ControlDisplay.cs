using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace PCM_SearchPage
{
    public class ControlDisplay
    {

        public  void SelectedMultipleDisplay(List<int> EDP_LIST, PlaceHolder placeholder1)
        {
            // save is an arraylist that contains EDP #
            placeholder1.Controls.Clear();
            for (int i = 0; i < EDP_LIST.Count; i++)
            {
                #region Naming , Creation of LAbel
                Label label_ProductName = new Label();
                label_ProductName.ID = "label_ProductName" + i;
                Label label_Store = new Label();
                label_Store.ID = "label_Store" + i;
                Label label_Description = new Label();
                label_Description.ID = "label_Description" + i;
                Label label_Price = new Label();
                label_Price.ID = "label_Price" + i;
                Image Image_url = new Image();
                Image_url.ID = "Image_ID" + i;
                Label label_Manufacturer = new Label();
                label_Manufacturer.ID = "label_Manufacturer" + i;
                Label label_Availability = new Label();
                label_Availability.ID = "label_Availability" + i;
                PlaceHolder ph = new PlaceHolder();
                ph.ID = "placeHold" + i;
                #endregion Naming , Creation of LAbel
                getDetails(Convert.ToString(EDP_LIST[i]), label_Store, label_ProductName, label_Description, label_Price, Image_url, label_Manufacturer, label_Availability);

                #region  IMPLEMENTATION
                Image_url.Height = 500;
                Image_url.Width = 500;
                Image_url.CssClass = "img-responsive ";
                Image_url.AlternateText = "No Image";
                //<----------  IMPLEMENT ----------->
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(Image_url);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("Price: "));
                ph.Controls.Add(label_Price);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("Name: "));
                ph.Controls.Add(label_ProductName);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("Store: "));
                ph.Controls.Add(label_Store);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("Description: "));
                ph.Controls.Add(label_Description);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("Manufacturer: "));
                ph.Controls.Add(label_Manufacturer);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color:red'>Availability: </label>"));
                ph.Controls.Add(label_Availability);
                ph.Controls.Add(new LiteralControl("</br>"));
                #endregion IMPLEMENTATION
                placeholder1.Controls.Add(ph);
            }
        }
        //Effective For Search ProductDetails
        public static void getDetails(String inputEdp, Label label_store, Label label_productName, Label label_productdescription,  
          Label label_Price, Image imageSourceUrl, Label label_Manufacturer, Label label_availabilityDescription) // VERSION 3
        { 
            String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + inputEdp + "&ignoreCatalog=true");
            System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
            while (reader.Read())
            {
                reader.ReadToFollowing("productDetails");
                while (reader.ReadToFollowing("manufacturer"))
                {
                    label_Manufacturer.Text = reader.ReadElementString("manufacturer");
                    reader.ReadToFollowing("storeSpecific");
                    reader.ReadToFollowing("store");
                    label_store.Text = reader.ReadElementString("store");
                    label_productName.Text = reader.ReadElementString("name");
                    while (reader.Read())
                    {
                        label_productdescription.Text = reader.Value;
                        break;
                    }
                    while (reader.ReadToFollowing("finalPrice"))
                    {
                        label_Price.Text = reader.ReadElementString("finalPrice"); break;
                    }
                    reader.ReadToFollowing("availabilityDescription");
                    if (reader.Name == "availabilityDescription") //
                    {
                        label_availabilityDescription.Text = reader.ReadElementString("availabilityDescription");
                    }
                    reader.ReadToFollowing("image");
                    reader.ReadToFollowing("xlg");
                    if (reader.Name == "xlg") //
                    {
                        imageSourceUrl.ImageUrl = reader.ReadElementString("xlg"); break;
                    }
                }
            }
            reader.Dispose();
        }
    }
}