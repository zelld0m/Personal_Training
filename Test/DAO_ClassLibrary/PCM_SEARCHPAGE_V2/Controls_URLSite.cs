using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCM_SEARCHPAGE_V2
{
    public class Controls_URLSite
    {
        #region Declaration of Variables
        private string searchManagerURL;
        private string alldetails_Use_EDP;
        private String findproduct;
        private int startRead;
        private int productLimitView = 10;
        private int brandLimit =10;

        #endregion
        #region GETTER SETTER
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
        public int StartRead
        {
            get
            {
                return startRead;
            }

            set
            {
                startRead = value;
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
     
        #endregion
        #region Using URL's
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

    }
}