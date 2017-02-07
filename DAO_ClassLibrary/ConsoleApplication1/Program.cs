using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(savingXmlReaderFiletoString());
           Console.WriteLine( downloadStringFromUrl());

            //hello();
            //sample();

            Console.ReadLine();
        }


        static void sample()
        {

            //XmlTextReader reader = new XmlTextReader("Books.xml");
            XmlTextReader reader = new XmlTextReader("EDP.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            Console.ReadLine();
       
        }



        


    
        /// <summary>
        /// Summary description for Class1.
        /// </summary>
       
        static void hello() 
        {
            String URLString = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0";
            XmlTextReader reader = new XmlTextReader(URLString);
            StringBuilder x = new StringBuilder();


            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

            Console.ReadLine();
          }




       static StringBuilder savingXmlReaderFiletoString()
        {
            String URLString = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0";
            XmlTextReader reader = new XmlTextReader(URLString);
            StringBuilder x = new StringBuilder();

            if (reader != null)
            {
                while (reader.Read())
                    x.AppendLine(reader.ReadOuterXml());
                Console.WriteLine(x);
            }
        
            return x;
        }
        static string downloadStringFromUrl()
        {
            string str;
            using (WebClient client = new WebClient())
            {
                str = client.DownloadString("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0");
            }
            return str;
           
        }
    }
}
