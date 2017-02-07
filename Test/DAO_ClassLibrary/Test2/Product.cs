using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test2
{
    [XmlRoot("product")]
    public class Product
    {
        [XmlAttribute("id")]
        public string ID
        {
            get;
            set;
        }
        [XmlAttribute("categoryname")]
        public string CategoryName
        {
            get;
            set;
        }
        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }
        [XmlElement("price")]
        public Price price
        {
            get;
            set;
        }
        [XmlElement("description")]
        public Description description
        {
            get;
            set;
        }
    }

    [XmlRoot("price")]
    public class Price
    {
        [XmlAttribute("unit")]
        public string Unit
        {
            get;
            set;
        }

        [XmlText]
        public int Value
        {
            get;
            set;
        }
    }

    [XmlRoot("description")]
    public class Description
    {
        [XmlElement("color")]
        public string Color
        {
            get;
            set;
        }
        [XmlElement("size")]
        public string Size
        {
            get;
            set;
        }
        [XmlElement("weight")]
        public string Weight
        {
            get;
            set;
        }

    }

}
