using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace PCM_SEARCHPAGE_V2
{
    public class XXX
    {
        private List<int> all_edp;
        private List<int> search_EDP;
        private List<int> brandFiltered_EDP;
        private List<string> brandList;
        private List<string> tempoBrand;
        private int numfoundFromSearch;
        private string all_EDPString;


        private String findproduct;
        private int currentpage;
        private int productLimitView;
        private int brandLimit;


        private string searchManagerURL;
        private string alldetails_Use_EDP;






        #region GETTER SETTER
       

        public List<int> Search_EDP
        {
            get
            {
                return search_EDP;
            }

            set
            {
                search_EDP = value;
            }
        }

        public List<int> BrandFiltered_EDP
        {
            get
            {
                return brandFiltered_EDP;
            }

            set
            {
                brandFiltered_EDP = value;
            }
        }

        public List<string> BrandList
        {
            get
            {
                return brandList;
            }

            set
            {
                brandList = value;
            }
        }

        public List<string> TempoBrand
        {
            get
            {
                return tempoBrand;
            }

            set
            {
                tempoBrand = value;
            }
        }

        public int NumfoundFromSearch
        {
            get
            {
                return numfoundFromSearch;
            }

            set
            {
                numfoundFromSearch = value;
            }
        }

        public string Findproduct
        {
            get
            {
                return findproduct;
            }

            set
            {
                findproduct = value;
            }
        }

        public int Currentpage
        {
            get
            {
                return currentpage;
            }

            set
            {
                currentpage = value;
            }
        }

        public int ProductLimitView
        {
            get
            {
                return productLimitView;
            }

            set
            {
                productLimitView = value;
            }
        }

        public int BrandLimit
        {
            get
            {
                return brandLimit;
            }

            set
            {
                brandLimit = value;
            }
        }

        public string SearchManagerURL
        {
            get
            {
                return searchManagerURL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + Findproduct + "&fl=EDP&store=pcmall&rows=" + ProductLimitView + "&start=" + Currentpage + "&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=" + BrandLimit; ;
            }

            set
            {
                searchManagerURL = value;
            }
        }

        public string Alldetails_Use_EDP
        {
            get
            {
                return alldetails_Use_EDP;
            }

            set
            {
                alldetails_Use_EDP = value;
            }
        }

        public List<int> All_edp
        {
            get
            {
                return all_edp;
            }

            set
            {
                all_edp = value;
            }
        }

        public string All_EDPString
        {
            get
            {
                return all_EDPString;
            }

            set
            {
                all_EDPString = value;
            }
        }
        #endregion

        #region EDP


        public  void getEDPfromSearchManager()
        {

            List<int> EDPLIST = new List<int>();


            string url = SearchManagerURL;   // SERVICE MANAGER WAS USED 
            if (All_edp != null)
            {
                All_edp.Clear();
            }
            System.Xml.XmlTextReader reader = new XmlTextReader(url);
            reader.ReadToFollowing("result");
            NumfoundFromSearch = Convert.ToInt32(reader.GetAttribute("numFound"));
            reader.ReadToFollowing("int");
            while (reader.GetAttribute("name") == "EDP")
            {
                EDPLIST.Add(Convert.ToInt32(reader.ReadElementString("int")));
                reader.ReadToFollowing("int");
            }
            All_edp = EDPLIST;
            all_EDPString = string.Join(",", EDPLIST);
        }

        public void generateBrandList()
        {
            if (BrandList != null)
            {
                BrandList.Clear();
            }
            for (int i = 0; i < All_edp.Count; i++)
            {
                String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + All_edp[i] + "&ignoreCatalog=true"); //  + 6926988/*EDP*/ +
                System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
                string brandx = "";
                int edp_tempo = 0;
                //   StringComparison comp = StringComparison.OrdinalIgnoreCase;
                while (reader.Read())
                {
                    while (reader.ReadToFollowing("edp"))
                    {
                        if (reader.Name == "edp")
                        {
                            edp_tempo = Convert.ToInt32(reader.ReadElementString("edp"));
                        }
                        if (reader.ReadToFollowing("manufacturer"))
                        {
                            brandx = reader.ReadElementString("manufacturer");
                        }
                        if (BrandList.Contains(brandx))
                        {
                        }
                        else BrandList.Add(brandx);

                    }
                }
            }
        }

        public void BrandSelected_Generate_EDP(string findBrand)
        {
            TempoBrand.Clear();
            BrandFiltered_EDP.Clear();
            if (Search_EDP.Count == 0)
            {
                Search_EDP = All_edp;
            }

            for (int i = 0; i < Search_EDP.Count; i++)
            {
                String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + Search_EDP[i] + "&ignoreCatalog=true"); //  + 6926988/*EDP*/ +
                System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
                string brandx = "";
                int edp_tempo = 0;
                //   StringComparison comp = StringComparison.OrdinalIgnoreCase;
                while (reader.Read())
                {
                    while (reader.ReadToFollowing("edp"))
                    {
                        if (reader.Name == "edp")
                        {
                            edp_tempo = Convert.ToInt32(reader.ReadElementString("edp"));
                        }
                        if (reader.ReadToFollowing("manufacturer"))
                        {
                            brandx = reader.ReadElementString("manufacturer");
                        }
                    }
                    if (brandx.ToLower().Contains(findBrand.ToLower()))
                    {
                        BrandFiltered_EDP.Add(edp_tempo);
                        if (TempoBrand.Contains(brandx))
                        {
                        }
                        else TempoBrand.Add(brandx);
                    }
                }
            }
        }

        #endregion


        #region DISPLAY
        public void SelectedMultipleDisplay(List<int> EDP_LIST, PlaceHolder placeholder1)
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



        public void SelectedMultipleDisplay2(string string_ALLEDP, PlaceHolder placeholder1)        //  ------------------  FIX THIS FOR MULTIPLE MAKE IT LIST 
        {
            // save is an arraylist that contains EDP #
            placeholder1.Controls.Clear();
            List<string> ProductName = new List<string>();
            List<string> Store = new List<string>();
            List<string> Description = new List<string>();
            List<string> Price = new List<string>();
            List<string> Url = new List<string>();
            List<string> Manufacturer = new List<string>();
            List<string> Availability = new List<string>();
            Label label_ProductName = new Label();
            label_ProductName.ID = "label_ProductName";
            Label label_Store = new Label();
            label_Store.ID = "label_Store";
            Label label_Description = new Label();
            label_Description.ID = "label_Description";
            Label label_Price = new Label();
            label_Price.ID = "label_Price";
            Image Image_url = new Image();
            Image_url.ID = "Image_ID";
            Label label_Manufacturer = new Label();
            label_Manufacturer.ID = "label_Manufacturer";
            Label label_Availability = new Label();
            label_Availability.ID = "label_Availability";

            #region Naming , Creation of LAbel

      
                #endregion Naming , Creation of LAbel
                getDetails2(Convert.ToString(All_EDPString),Store, ProductName, Description, Price, Url, Manufacturer, Availability);

            #region  IMPLEMENTATION
            Image_url.Height = 500;
            Image_url.Width = 500;
            Image_url.CssClass = "img-responsive ";
            Image_url.AlternateText = "No Image";
            //<----------  IMPLEMENT ----------->


            for (int i = 0; i < Store.Count; i++)
                {
                PlaceHolder ph = new PlaceHolder();
                ph.ID = "ph" + i;
                label_ProductName.Text = ProductName[i];
                label_Store.Text = Store[i];
                label_Description.Text = Description[i];
                label_Manufacturer.Text = Manufacturer[i];
                label_Price.Text = Price[i];
                Image_url.Height = 500;
                Image_url.Width = 500;
                Image_url.CssClass = "img-responsive ";
                Image_url.AlternateText = "No Image";
                if (Url[i] == null)
                {
                    Image_url.CssClass = "img-responsive ";
                }
                Image_url.ImageUrl = Url[i]; 
                label_Availability.Text = Availability[i];



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
                    if (listBrand.Contains(label_Manufacturer.Text))
                    {
                        
                    }
                    else listBrand.Add(label_Manufacturer.Text);

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

        public static void getDetails2(String inputEdp, List<string> label_store, List<string> label_productName, List<string> label_productdescription,
         List<string> label_Price, List<string> imageSourceUrl, List<string> label_Manufacturer, List<string> label_availabilityDescription) // VERSION 3
        {
            String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + inputEdp + "&ignoreCatalog=true");
            System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
            while (reader.Read())
            {
                while (reader.ReadToFollowing("result"))
                {
                    reader.ReadToFollowing("productDetails");
                    while (reader.ReadToFollowing("manufacturer"))
                    {
                        label_Manufacturer.Add(reader.ReadElementString("manufacturer"));
                        reader.ReadToFollowing("storeSpecific");
                        reader.ReadToFollowing("store");
                        label_store.Add(reader.ReadElementString("store"));
                        label_productName.Add(reader.ReadElementString("name")); 


                        while (reader.ReadToFollowing("description"))
                        {
                            label_productdescription.Add(reader.Value); break;

                        }
                        while (reader.ReadToFollowing("finalPrice"))
                        {
                            label_Price.Add(reader.ReadElementString("finalPrice")); break;
                        }
                        while (reader.ReadToFollowing("availabilityDescription"))
                        {

                            label_availabilityDescription.Add(reader.ReadElementString("availabilityDescription")); break;
                        }
                        if (reader.ReadToFollowing("images"))
                        {
                            if (reader.Name == "image")
                            {
                                while (reader.ReadToFollowing("xlg"))
                                {

                                    imageSourceUrl.Add(reader.ReadElementString("xlg")); break;
                                }
                            }
                            else if (reader.ReadToFollowing("hasImage"))
                            {
                                imageSourceUrl.Add("NO IMAGE"); 
                            }

                        }
                    }

                }
            }
            reader.Dispose();
        }
        #endregion

        #region IMPLEMENTATION
        static List<String> listBrand = new List<string>();

    

        public void radioButton_button(String findBrand, RadioButtonList radiobuttonlist, PlaceHolder PlaceHolder1)
        {
            BrandSelected_Generate_EDP(findBrand);
            SelectedMultipleDisplay(BrandFiltered_EDP, PlaceHolder1);

            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            listBrand = TempoBrand;
            for (int i = 0; i < listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
        }

        public void searchButton(string search, RadioButtonList radiobuttonlist, PlaceHolder PlaceHolder1)   // useThis as Clear Filter
        {



            listBrand.Clear();
            Findproduct = search;
            getEDPfromSearchManager();
         //   SelectedMultipleDisplay(All_edp, PlaceHolder1);
            SelectedMultipleDisplay2(all_EDPString, PlaceHolder1);
            radiobuttonlist.ClearSelection();
            radiobuttonlist.Controls.Clear();
            radiobuttonlist.Items.Clear();
            
            for (int i = 0; i < listBrand.Count; i++)
            {
                radiobuttonlist.Items.Add(new ListItem(listBrand[i]));
            }
            radiobuttonlist.AutoPostBack = true;
        }

        public void dropdownList_NumViews(DropDownList drop)
        {
            int x = Convert.ToInt32(drop.SelectedValue);
            ProductLimitView = x;
        }



        public void nextPage(Label lbl_PageNumber, DropDownList drpdwnlst_View, Label lbl_Min, Label lbl_MAX)
        {
            ///----------------------------------------


            int pagenumber = Convert.ToInt32(lbl_PageNumber.Text) + 1;

            int min = Convert.ToInt32(drpdwnlst_View.SelectedValue) * pagenumber;
            int max = Convert.ToInt32(drpdwnlst_View.SelectedValue) + min;
            lbl_Min.Text = "" + min;
            lbl_MAX.Text = "" + max;
            Currentpage = (Convert.ToInt32(pagenumber));
            lbl_PageNumber.Text = "" + pagenumber;

        }
        public void previousPage(Label lbl_PageNumber, DropDownList drpdwnlst_View, Label lbl_Min, Label lbl_MAX)
        {
            ///----------------------------------------
            int pagenumber = Convert.ToInt32(lbl_PageNumber.Text);
            if (pagenumber > 0)
            {
                pagenumber = Convert.ToInt32(lbl_PageNumber.Text) - 1;
                int min = Convert.ToInt32(drpdwnlst_View.SelectedValue) * pagenumber;
                int max = Convert.ToInt32(drpdwnlst_View.SelectedValue) + min;
                lbl_Min.Text = "" + min;
                lbl_MAX.Text = "" + max;
                Currentpage = (Convert.ToInt32(pagenumber));

                lbl_PageNumber.Text = "" + pagenumber;
            }
        }

        #endregion

    }
}