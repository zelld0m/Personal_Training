using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace PCM_SEARCHPAGE_V2
{
    public class Control_Display
    {
        #region Declaration of Variable List
        List<String> Superstorage = new List<string>();
        List<string> productName = new List<string>();
        List<string> store = new List<string>();
        List<string> productDescription = new List<string>();
        List<string> price = new List<string>();
        List<string> imageurl = new List<string>();
        List<string> manufacturer = new List<string>();
        List<string> availability = new List<string>();

        public List<string> Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
            }
        } 
        #endregion
        #region OLD not used

        //public void SelectedMultipleDisplay(List<int> EDP_LIST, PlaceHolder placeholder1)
        //{
        //    // save is an arraylist that contains EDP #
        //    placeholder1.Controls.Clear();
        //    for (int i = 0; i < EDP_LIST.Count; i++)
        //    {
        //        #region Naming , Creation of LAbel
        //        Label label_ProductName = new Label();
        //        label_ProductName.ID = "label_ProductName" + i;
        //        Label label_Store = new Label();
        //        label_Store.ID = "label_Store" + i;
        //        Label label_Description = new Label();
        //        label_Description.ID = "label_Description" + i;
        //        Label label_Price = new Label();
        //        label_Price.ID = "label_Price" + i;
        //        Image Image_url = new Image();
        //        Image_url.ID = "Image_ID" + i;
        //        Label label_Manufacturer = new Label();
        //        label_Manufacturer.ID = "label_Manufacturer" + i;
        //        Label label_Availability = new Label();
        //        label_Availability.ID = "label_Availability" + i;
        //        PlaceHolder ph = new PlaceHolder();
        //        ph.ID = "placeHold" + i;
        //        #endregion Naming , Creation of LAbel
        //        getDetails(Convert.ToString(EDP_LIST[i]), label_Store, label_ProductName, label_Description, label_Price, Image_url, label_Manufacturer, label_Availability);

        //        #region  IMPLEMENTATION
        //        Image_url.Height = 500;
        //        Image_url.Width = 500;
        //        Image_url.CssClass = "img-responsive ";
        //        Image_url.AlternateText = "No Image";
        //        //<----------  IMPLEMENT ----------->
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(Image_url);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("Price: "));
        //        ph.Controls.Add(label_Price);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("Name: "));
        //        ph.Controls.Add(label_ProductName);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("Store: "));
        //        ph.Controls.Add(label_Store);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("Description: "));
        //        ph.Controls.Add(label_Description);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("Manufacturer: "));
        //        ph.Controls.Add(label_Manufacturer);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        ph.Controls.Add(new LiteralControl("<label style='color:red'>Availability: </label>"));
        //        ph.Controls.Add(label_Availability);
        //        ph.Controls.Add(new LiteralControl("</br>"));
        //        #endregion IMPLEMENTATION
        //        placeholder1.Controls.Add(ph);
        //    }
        //}
        ////Effective For Search ProductDetails
        //public  void getDetails(String inputEdp, Label label_store, Label label_productName, Label label_productdescription,
        //  Label label_Price, Image imageSourceUrl, Label label_Manufacturer, Label label_availabilityDescription) // VERSION 3
        //{
        //    String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + inputEdp + "&ignoreCatalog=true");
        //    System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
        //    while (reader.Read())
        //    {

        //        reader.ReadToFollowing("productDetails");
        //        while (reader.ReadToFollowing("manufacturer"))
        //        {
        //            label_Manufacturer.Text = reader.ReadElementString("manufacturer");
        //            reader.ReadToFollowing("storeSpecific");
        //            reader.ReadToFollowing("store");
        //            label_store.Text = reader.ReadElementString("store");
        //            label_productName.Text = reader.ReadElementString("name");
        //            while (reader.Read())
        //            {
        //                label_productdescription.Text = reader.Value;
        //                break;
        //            }
        //            while (reader.ReadToFollowing("finalPrice"))
        //            {
        //                label_Price.Text = reader.ReadElementString("finalPrice"); break;
        //            }
        //            reader.ReadToFollowing("availabilityDescription");
        //            if (reader.Name == "availabilityDescription") //
        //            {
        //                label_availabilityDescription.Text = reader.ReadElementString("availabilityDescription");
        //            }
        //            reader.ReadToFollowing("image");
        //            reader.ReadToFollowing("xlg");
        //            if (reader.Name == "xlg") //
        //            {
        //                imageSourceUrl.ImageUrl = reader.ReadElementString("xlg"); break;
        //            }
        //        }
        //    }
        //    reader.Dispose();
        //}

        #endregion
        #region new  used   GET AND DISPLAY
        public void SelectedMultipleDisplay2(PlaceHolder placeholder1)
        {
            // save is an arraylist that contains EDP #
            

            placeholder1.Controls.Clear();
            for (int i = 0; i < productName.Count; i++)
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
                
                #region  IMPLEMENTATION
                Image_url.Height = 200;
                Image_url.Width = 200;
                Image_url.CssClass = "img-responsive ";
                Image_url.AlternateText = "No Image";
                //<----------  IMPLEMENT ----------->
                Image_url.ImageUrl = imageurl[i];
                label_ProductName.Text = productName[i];
                label_Store.Text = store[i];
                label_Description.Text = productDescription[i];
                label_Price.Text = price[i];
                label_Manufacturer.Text = Manufacturer[i];
                label_Availability.Text = availability[i];
                ph.Controls.Add(new LiteralControl("<label style = color:blue'></br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("</br>"));
                if(Image_url.ImageUrl== "NO IMAGE"){
                    Image_url.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";
                }
                ph.Controls.Add(Image_url);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color: blue'> Price: "));
                label_Price.ForeColor = System.Drawing.Color.Red;
                ph.Controls.Add(label_Price);
                ph.Controls.Add(new LiteralControl("</label></br>"));
               
                ph.Controls.Add(new LiteralControl("<label style='color: blue'> Name:</label> "));
                ph.Controls.Add(label_ProductName);
          
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color: blue'> Store:</label> "));
                ph.Controls.Add(label_Store);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color: blue'> Description:</label> "));
                if(label_Description.Text == "N")
                {
                    label_Description.Text = " No Description";
                    label_Description.ForeColor = System.Drawing.Color.DarkOrange;
                }
                ph.Controls.Add(label_Description);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color: blue'> Manufacturer:</label> "));
                ph.Controls.Add(label_Manufacturer);
                ph.Controls.Add(new LiteralControl("</br>"));
                ph.Controls.Add(new LiteralControl("<label style='color: blue'>Availability: "));
                #region Availability Condition
                if (label_Availability.Text == "Temporarily out of stock. Order today and we'll deliver when available.")
                {
                    label_Availability.ForeColor = System.Drawing.Color.DarkOrange;
                }
                else if (label_Availability.Text == "In stock. Usually ships next business day.")
                {

                    label_Availability.ForeColor = System.Drawing.Color.ForestGreen;
                }
                else if (label_Availability.Text == "Sold Out")
                {
                    label_Availability.ForeColor = System.Drawing.Color.Red;
                } 
                #endregion
                ph.Controls.Add(label_Availability);
                ph.Controls.Add(new LiteralControl("</label></br>"));
                ph.Controls.Add(new LiteralControl("</br></label>"));
                #endregion IMPLEMENTATION
                placeholder1.Controls.Add(ph);
            }
        }

        public  void getDetails2(String url_For_EDP_details) // VERSION 3
        {
            productName.Clear();
            store.Clear();
            productDescription.Clear();
            price.Clear();
            imageurl.Clear();
            Manufacturer.Clear();
            availability.Clear();
            
            Label label_store = new Label();
            Label label_productName = new Label(); ;
            Label label_productdescription = new Label(); ;
            Label label_Price = new Label(); ;
            Image imageSourceUrl = new Image();  Label label_Manufacturer = new Label(); ;
            Label label_availabilityDescription = new Label(); 
     
            System.Xml.XmlTextReader reader = new XmlTextReader(url_For_EDP_details);
            while (reader.Read())
            {
                while (reader.ReadToFollowing("item"))
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
                        while (reader.ReadToFollowing("images"))
                        {
                            if (reader.Read())
                            {
                                if (reader.Name == ("image"))
                                {
                                   reader.ReadToFollowing("xlg");
                                        if (reader.Name == "xlg") //
                                        {
                                            imageSourceUrl.ImageUrl = reader.ReadElementString("xlg"); break;
                                        }
                                    
                                } else imageSourceUrl.ImageUrl = "NO IMAGE"; break;
                            }
                           

                        }
                        
                        store.Add(label_store.Text);
                        productName.Add(label_productName.Text);

                        price.Add(label_Price.Text);
                        productDescription.Add(label_productdescription.Text);
                        Manufacturer.Add(label_Manufacturer.Text);
                        availability.Add(label_availabilityDescription.Text);
                        imageurl.Add(imageSourceUrl.ImageUrl);
                       
                    }


                }
            }
            reader.Dispose();
        } 
        #endregion
    }
}