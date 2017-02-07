using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LIST _ Serialization

            //LIST PRODUCT SERIALIZATION

            try
            {
                List<Product> listProduct = new List<Product>();
                listProduct.Add(new Product
                {
                    ID = "p01",
                    Name = "product Name 1",
                    CategoryName = "category 1",
                    price = new Price { Value = 100, Unit = "USD" },
                    description = new Description { Color = "RED", Size = "Size dd1", Weight = "100gr" }
                });
                listProduct.Add(new Product
                {
                    ID = "p02",
                    Name = "product Name 2",
                    CategoryName = "category 2",
                    price = new Price { Value = 100, Unit = "AUD" },
                    description = new Description { Color = "BLUE", Size = "Size 2", Weight = "200gr" }
                });

                listProduct.Add(new Product
                {
                    ID = "p03",
                    Name = "product Name 3",
                    CategoryName = "category 3",
                    price = new Price { Value = 100, Unit = "EUR" },
                    description = new Description { Color = "yellow", Size = "Size 3", Weight = "300gr" }
                });
                //--------ERROR 
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));

                StreamWriter sw = new StreamWriter("listProduct.xml");

                xmlSerializer.Serialize(sw, listProduct);
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));  // FORMATTER
                StreamReader sr = new StreamReader("listProduct.xml");     // GET FROM
                List<Product> listProduct = (List<Product>)xmlSerializer.Deserialize(sr);     // DESERIALIZE PRODUCTS
                foreach (Product product in listProduct) // SHOW ALL PRODUCTS
                {
                    Console.WriteLine("list Product Information");
                    Console.WriteLine("ID: " + product.ID);
                    Console.WriteLine("NAME: " + product.Name);
                    Console.WriteLine("Price: " + product.price.Value);
                    Console.WriteLine("unit: " + product.price.Unit);
                    Console.WriteLine("Color: " + product.description.Color);
                    Console.WriteLine("Size: " + product.description.Size);
                    Console.WriteLine("Weight: " + product.description.Weight);
                    Console.Write("__________________________________________");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion LIST _ Serialization

            //product Serialization
            /*   try
               {
                   Product product = new Product
                   {
                       ID = "p01",
                       Name = "product Name 1",
                       CategoryName = "category 1",
                       price = new Price { Value = 100, Unit = "USD" },
                       description = new Description { Color = "RED", Size = "Size dd1", Weight = "100gr" }
                   };
               //--------ERROR 
                   XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
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
               */
            //Product Desirialization
            /*
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                StreamReader sr = new StreamReader("Product.xml");
                Product Product = (Product)xmlSerializer.Deserialize(sr);
                Console.WriteLine("Product Information");
                Console.WriteLine("ID: " + Product.ID);
                Console.WriteLine("NAME: " + Product.Name);
                Console.WriteLine("Price: " + Product.price.Value);
                Console.WriteLine("unit: " + Product.price.Unit);
                Console.WriteLine("Color: " + Product.description.Color);
                Console.WriteLine("Size: " + Product.description.Size);
                Console.WriteLine("Weight: " + Product.description.Weight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion De _ Serialization
            Console.ReadLine();
            */
        }
    }
}
