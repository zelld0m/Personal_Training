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
        static List<string> TempoBrand = new List<string>();
        static  int numfoundFromSearch = 0;
        #region SETTER
        public  void getEDPfromSearchManager() {              // SUCCESS   
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

        public  void generateBrandList()    
        {
            BrandList.Clear();
            for (int i = 0; i < ALL_EDP.Count; i++)
            {
                String inputurl = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + ALL_EDP[i] + "&ignoreCatalog=true"); //  + 6926988/*EDP*/ +
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
      
        public  void BrandSelected_Generate_EDP(string findBrand)
        {
            TempoBrand.Clear();
            BrandFiltered_EDP.Clear();
            if (Search_EDP.Count == 0)
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
                            if (TempoBrand.Contains(brandx))
                            {
                            }
                            else TempoBrand.Add(brandx);
                        }
                    }
                
            }
           
        }
        
        #endregion




        #region GETTER
        public  List<int> getAll_EDP()
        {
            getEDPfromSearchManager();
            return ALL_EDP;
        }
        
        public  List<string> getBrand()
        {
            generateBrandList();
            return BrandList;
        }
        public  List<int> getBranded_EDP()
        {
            return BrandFiltered_EDP;
        }
        public int getNumfound()
        {
            return numfoundFromSearch;
        }
        public List<string> getTempoBrand()
        {
            return TempoBrand;
        }
        #endregion
    }
}