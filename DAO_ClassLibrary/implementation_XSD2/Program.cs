using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;
namespace implementation_XSD2
{ /// <summary>   
///  http://stackoverflow.com/questions/60573/xmlserializer-there-was-an-error-reflecting-type?answertab=active#tab-top // problem fixed on reflection
///  https://www.youtube.com/watch?v=UvEF7UPh1Qg#t=209.781108             // video
/// http://xsd2code.codeplex.com/                                       // tutorial xsd2code
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region LIST _ Serialization
            //LIST PRODUCT SERIALIZATION
            try
            {
                product product = new product { 
                    id = "p01",
                    name = "product Name 1",
                    categoryname = "category 1",
                    price = new productPrice { Value = 100, unit = "USD" },
                    description = new productDescription { color = "RED", size = "Size dd1", weight = "100gr" }
                };
                //--------ERROR 
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(product));
                StreamWriter sw = new StreamWriter("Product.xml");
                xmlSerializer.Serialize(sw, product);
                sw.Close();
                //ERROR
                Console.WriteLine("Serialization Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /// LIST Desirialization
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(product));  // FORMATTER
                StreamReader sr = new StreamReader("Product.xml");     // GET FROM
                product product = (product) xmlSerializer.Deserialize(sr);     // DESERIALIZE PRODUCTS
               
                    Console.WriteLine("list Product Information");
                    Console.WriteLine("ID: " + product.id);
                    Console.WriteLine("NAME: " + product.name);
                    Console.WriteLine("Price: " + product.price.Value);
                    Console.WriteLine("unit: " + product.price.unit);
                    Console.WriteLine("Color: " + product.description.color);
                    Console.WriteLine("Size: " + product.description.size);
                    Console.WriteLine("Weight: " + product.description.weight);
                    Console.Write("__________________________________________");
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion LIST _ Serialization

    }
}
