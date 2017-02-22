using MVCDEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVCDEMO.Controllers
{
    public class ProductController : Controller
    {

       // public DataContext db = new DataContext();    // Use this as database connection
        #region ForListing
        List<int> All_edp { get; set; }
        List<int> Search_Edp { get; set; }
        List<int> BrandFiltering_Edp { get; set; }
        List<string> BrandList { get; set; }
        List<string> TemploBrand { get; set; }
        int NumfoundFromSearch { get; set; }
        string EdpString { get; set; }
        List<string> FullBrand { get; set; }
        List<string> BrandCount { get; set; }
        List<int> EDPLIST = new List<int>();

        public void getEDPfromSearchManager2(string SearchManagerURL)
        {
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
            EdpString = string.Join(",", EDPLIST);
        }
        
        public void getDetails2(String url_For_EDP_details)
        {
            products.Clear();
            System.Xml.XmlTextReader reader = new XmlTextReader(url_For_EDP_details);
            while (reader.Read())
            {
                while (reader.ReadToFollowing("item"))
                {
                    reader.ReadToFollowing("productDetails");
                    while (reader.ReadToFollowing("manufacturer"))
                    {
                        product.Manufacturer = reader.ReadElementString("manufacturer");
                        reader.ReadToFollowing("storeSpecific");
                        reader.ReadToFollowing("store");
                        product.Store = reader.ReadElementString("store");
                        product.ProductName = reader.ReadElementString("name");
                        while (reader.Read())
                        {
                            product.ProductDescription = reader.Value;
                            break;
                        }
                        while (reader.ReadToFollowing("finalPrice"))
                        {
                            product.Price = reader.ReadElementString("finalPrice"); break;
                        }
                        reader.ReadToFollowing("availabilityDescription");
                        if (reader.Name == "availabilityDescription") 
                        {
                            product.Availability = reader.ReadElementString("availabilityDescription");
                        }
                        while (reader.ReadToFollowing("images"))
                        {
                            if (reader.Read())
                            {
                                if (reader.Name == ("image"))
                                {
                                    reader.ReadToFollowing("xlg");
                                    if (reader.Name == "xlg") 
                                    {
                                        product.Imageurl = reader.ReadElementString("xlg"); break;
                                    }
                                }
                                else product.Imageurl = "NO IMAGE"; break;
                            }
                        }
                        products.Add(product);
                    }
                }
            }
            reader.Dispose();
        }
        #endregion
        
        #region URL

        private string searchManagerURL;
        private string alldetails_Use_EDP;
        private String findproduct;
        private int startRead;
        private int productLimitView = 10;
        private int brandLimit = 10;

        public string Findproduct { get; set; }
        public int StartRead { get; set; }
        public int ProductLimitView { get; set; }
        public int BrandLimit { get; set; }

        public string SearchManagerURL
        {
            get
            {
                return searchManagerURL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + Findproduct + "&fl=EDP&store=pcmall&rows=" + ProductLimitView + "&start=" + StartRead + "&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=" + BrandLimit;
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
                alldetails_Use_EDP = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + value + "&ignoreCatalog=true";
            }
        }

        #endregion

        
        #region ForSaving ProductDetails
        List<Product> products = new List<Product>();
        Product product = new Product();
        #endregion


        public ActionResult Index() // just return a view here
        {
            return View();
        }

        
    }
}