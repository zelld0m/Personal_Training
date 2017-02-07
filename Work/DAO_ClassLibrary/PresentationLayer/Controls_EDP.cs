using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace PresentationLayer
{

    
    public class Controls_EDP
    {
        #region Declaration
        private List<string> testlist = new List<string>();
        private List<int> testbrandcount = new List<int>();
        private List<int> all_edp;
        private List<int> search_EDP;
        private List<int> brandFiltered_EDP;
        private List<string> brandList;
        private List<string> tempoBrand;
        private List<string> fullBrand = new List<string>();
        private List<string> brandCount = new List<string>();
        private int numfoundFromSearch;
        private string edpString;

        #endregion   
        #region Getter : Setter

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
        public string EdpString
        {
            get
            {
                return edpString;
            }

            set
            {
                edpString = value;
            }
        }
        public List<string> FullBrand
        {
            get
            {
                return fullBrand;
            }

            set
            {
                fullBrand = value;
            }
        }
        public List<string> BrandCount
        {
            get
            {
                return brandCount;
            }

            set
            {
                brandCount = value;
            }
        }

        
        #endregion
        #region SETTER
    
        public void getEDPfromSearchManager2(string SearchManagerURL)
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
            EdpString = string.Join(",", EDPLIST);
        }
        #region  Unused GetALL Brand
        public void AllBrand2(string SearchManagerURL)  // GET ALL BRAND   Use This to show all brand  
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(SearchManagerURL);
            reader.ReadToFollowing("lst");
            reader.ReadToFollowing("lst");//reader.Skip();reader.Skip();
            reader.ReadToFollowing("lst");
            reader.ReadToFollowing("lst");
            reader.ReadToFollowing("lst");
            while (reader.Read())
            {
                if ((reader.GetAttribute("name") == "Manufacturer"))
                {
                    
                    while (reader.ReadToFollowing("int") && (reader.GetAttribute("name") != "true") && (reader.GetAttribute("name") != "false"))
                    {
                        FullBrand.Add (Convert.ToString(reader.GetAttribute("name")));  // GOT ALL BRAND
                        reader.Read();
                        BrandCount.Add( reader.Value); // GOT ALL COUNT
                    }
                }
            }
        }
        
        #endregion
        #endregion

    }
}