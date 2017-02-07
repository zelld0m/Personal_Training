using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;


/// <summary>   
///  http://stackoverflow.com/questions/60573/xmlserializer-there-was-an-error-reflecting-type?answertab=active#tab-top // problem fixed on reflection
///  https://www.youtube.com/watch?v=UvEF7UPh1Qg#t=209.781108             // video
/// http://xsd2code.codeplex.com/                                       // tutorial xsd2code
/// </summary>


namespace Serialization_Deserialization
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region De _ Serialization
            #region CreateXML
            //product Serialization
            try
            {
                product product = new product
                {
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
            #endregion CreateXML
            //Product Desirialization


            #endregion De _ Serialization
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Product.designer.cs was generated from Xsd2 code generator
           
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(product));  // FORMATTER Chopchop
                StreamReader sr = new StreamReader("Product.xml");     // read product.xml
                product product = (product)xmlSerializer.Deserialize(sr);
            // DESERIALIZE deserialize the reader that has product.xml

                Console.WriteLine("list Product Information");
                TB_ID.Text= product.id;
                TB_Name.Text= product.name;
                TB_Price.Text= Convert.ToString( product.price.Value);
                TB_Unit.Text= product.price.unit;
             ///   Console.WriteLine("Color: " + product.description.color);
             //   Console.WriteLine("Size: " + product.description.size);
             //   Console.WriteLine("Weight: " + product.description.weight);
              //  Console.Write("__________________________________________");

           
        }
    }
}