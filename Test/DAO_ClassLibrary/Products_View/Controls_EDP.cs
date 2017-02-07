using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace UsingStreamReader
{
    public class Controls_EDP
    {
        static List<int> ALL_EDP = new List<int>();
        static List<int> Search_EDP = new List<int>();
        static List<int> BrandFiltered_EDP = new List<int>();
        static List<string> BrandList = new List<string>();
        static  int numfoundFromSearch = 0;
        #region SETTER
        public static void getEDPfromSearchManager() {              // SUCCESS   
            ALL_EDP.Clear();
            string url =   Controls_URL.SearchManagerPage_URL();   // SERVICE MANAGER WAS USED 
            System.Xml.XmlTextReader reader = new XmlTextReader(url);
            reader.ReadToFollowing("result");
            numfoundFromSearch = Convert.ToInt32(reader.GetAttribute("numFound"));
            reader.ReadToFollowing("int");
            while (reader.GetAttribute("name") == "EDP")
            {
                ALL_EDP.Add(Convert.ToInt32(reader.ReadElementString("int")));
                reader.ReadToFollowing("int");
            }
        }

        public static void SearchFiltering_EDP(string find)
        {
            Search_EDP.Clear();
            BrandList.Clear();
            for (int i = 0; i < ALL_EDP.Count; i++)
            {
                String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + ALL_EDP[i] + "&ignoreCatalog=true"); //  + 6926988/*EDP*/ +
                System.Xml.XmlTextReader reader = new XmlTextReader(inputurl);
                string brandx = "";
                string category = "";
                string class1 = "";
                string name = "";
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
                            reader.ReadToFollowing("category");
                            //if (reader.ReadToFollowing("category")) // SAVE category save brand save edp
                            {
                                category = reader.ReadElementString("category");
                                reader.ReadToFollowing("class");
                                if (reader.Name == "class")
                                {
                                    class1 = reader.ReadElementString("class");
                                }
                                reader.ReadToFollowing("store");
                                reader.ReadToFollowing("name");
                                if (reader.Name == "name")
                                {
                                    name = reader.ReadElementString("name");
                                }
                            }
                        }
                    }
                    if (brandx.ToLower().Contains(find.ToLower()) || category.ToLower().Contains(find.ToLower()) || class1.ToLower().Contains(find.ToLower()) || name.ToLower().Contains(find.ToLower()))
                    {
                        Search_EDP.Add(edp_tempo);
                        if ("" != find)
                        {
                            if (BrandList.Contains(brandx)) { }
                            else BrandList.Add(brandx);
                        }
                    }
                }
            }
        }
      
        public static void BrandFiltering_EDP(string findBrand)
        {
            BrandFiltered_EDP.Clear();
            BrandList.Clear();
            if (Search_EDP == null)
            {
                Search_EDP = ALL_EDP;
            }
            else
            { }
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
                            BrandList.Add(brandx);
                        }
                    }
                
            }
           
        }
        
        #endregion




        #region GETTER
        public static List<int> getAll_EDP()
        {
            getEDPfromSearchManager();
            return ALL_EDP;
        }
        
        public static List<int> getsearch_EDP(string find)
        {
            SearchFiltering_EDP(find);
            return Search_EDP;
        }
        public static List<int> getBrandFiltered_EDP()
        {
            return BrandFiltered_EDP;
        }
        #endregion
    }
}