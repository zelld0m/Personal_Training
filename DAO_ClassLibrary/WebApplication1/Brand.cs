using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace WebApplication1
{
    [XmlRoot("Response")]
    public class Brand  // Main 
    {
        [XmlAttribute("responseHeader")]
        public string responseHeader
        {
            get;set;
        }
        [XmlAttribute("response")]
        public int response
        {
            get;set;
        }

        [XmlAttribute("spellcheck")]
        public string spellcheck
        {
            get;set;
        }
      

    }

    [XmlElement("responseHeader")]
    public class responseHeader
    {
      
        [XmlElement("status")]
        public string status
        {
            get; set;
        }
        [XmlElement("QTime")]
        public string QTime
        {
            get; set;
        }
        [XmlElement("parameter")]
        public string parameter   // invalid param
        {
            get; set;
        }
    }

    public class parameter
    {
        [XmlAttribute("q")]
        public string q
        {
            get; set;
        }
        [XmlAttribute("qt")]
        public string qt
        {
            get; set;
        }
        [XmlAttribute("echoParams")]
        public string echoParams
        {
            get; set;
        }
        [XmlAttribute("fl")]
        public string fl
        {
            get; set;
        }
        [XmlAttribute("start")]
        public string start
        {
            get; set;
        }
        [XmlAttribute("store")]
        public string store
        {
            get; set;
        }
        [XmlAttribute("rows")]
        public string rows
        {
            get; set;
        }

    }
}