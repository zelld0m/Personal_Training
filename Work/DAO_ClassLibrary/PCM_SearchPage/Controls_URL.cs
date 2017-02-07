using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCM_SearchPage
{
    public class Controls_URL
    {

        #region Declaration
        static String Findproduct = "laptop";
        static int Currentpage = 0;
        static int ProductLimitView = 5;
        static int BrandLimit = 10;
        #endregion

        #region Change VALUE
        public  void Find(String find)
        {
            Findproduct = find;
        }
        public void ChangePage(int page)  // increment By 1   //Start reading From "page"
        {
            page = page * ProductLimitView;
            Currentpage = page;
        }


        public void LimitView(int productLimitView) {
            ProductLimitView = productLimitView;
        }
       public void ChangeBrandLimit(int limit)
        {
            BrandLimit = limit;
        }
        #endregion

        #region URL CONTROLS
        public static string SearchManagerPage_URL()
        {
            string searchmanager_URL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + Findproduct + "&fl=EDP&store=pcmall&rows=" + ProductLimitView + "&start=" + Currentpage + "&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=" + BrandLimit;
            return searchmanager_URL;
        }

        public static string productDetails_URL(int input_EDP)
        {
            String productDetails_URL = ("http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + input_EDP + "&ignoreCatalog=true");
            return productDetails_URL;
        }
        // GET NUMFOUND


        public  int  getpage()
        {
            return Currentpage;
        }
        #endregion


    }

}