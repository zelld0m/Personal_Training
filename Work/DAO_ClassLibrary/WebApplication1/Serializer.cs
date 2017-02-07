using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication1
{
    public class Serializer<T>
    {

        public static void SerializeXmlObjectToStream(Stream stream, T theObject)
        {
            XmlSerializer serial = new XmlSerializer(theObject.GetType());
            serial.Serialize(stream, theObject);
        }
        public static T XmlStreamToObject(Stream XmlStream)
        { 
            XmlSerializer serial = new XmlSerializer(typeof(T));
            return (T)serial.Deserialize(XmlStream);
        }
        public static T XmlStringToObject(String XmlString)
         {
            XmlSerializer serial = new XmlSerializer(typeof(T));
            return (T)serial.Deserialize(new StringReader(XmlString));
        }

    }


         [XmlRoot("subscriptionExists")]
        public class SubscriptionExistsRequest
        {
        [XmlElement("UserID")]
        public int UserID { get; set; }
        [XmlElement("Username")]
        public String Username { get; set; }
        [XmlElement("ProductID")]
            public int ProductID { get; set; }
        } 

}


