using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Trying_XMLreader : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            #region error
            /*
             GridView1.DataSource = RunSample();
            TreeView1.DataSource = RunSample();
            GridView1.DataBind();
            PostObjectToURL("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=10", dt);

            // GridView1.DataSource = dt;
            GridView1.DataBind();
            inputURL("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=10");
            usingload();
            usingReader();
            */
            #endregion

        }


        #region Errors

        /*---------------- START
        static void usingReader()
        {
            using (XmlReader reader = XmlReader.Create("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=10"))
            {
                reader.ReadStartElement("Response");
                while (reader.Name == "TheNodeIWant")
                {
                    XElement el = (XElement)XNode.ReadFrom(reader);
                }
                reader.ReadEndElement();
            }
        }

    static IEnumerable<XElement> SimpleStreamAxis(string inputUrl,string elementName)
    {
        using (XmlReader reader = XmlReader.Create(inputUrl))
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == elementName)
                    {
                        XElement el = XNode.ReadFrom(reader) as XElement;
                        if (el != null)
                        {
                            yield return el;
                        }
                    }
                }
            }
        }
    }


    void inputURL(String url)
    {
        String urlx = @"" + url + "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(urlx);
    }
    //--
    static void usingload(){
    var document = XDocument.Load("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=10");
        }
    //==


    private Boolean PostObjectToURL(String url, Object obj)
    {
         WebRequest request = WebRequest.Create(url);
         request.ContentType = "text/xml";
         request.Method = "POST";
         Stream requestStream = request.GetRequestStream();
         // Serializer using dynamic to get around compile time type checking
         Serializer<dynamic>.SerializeXmlObjectToStream(requestStream, obj);
         requestStream.Close();
         using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
         {
             return (response.StatusCode == HttpStatusCode.OK);
         }
    } 




        public GeneratedClassFromXSD GetObjectFromXML()
        {
            var settings = new XmlReaderSettings();
            var obj = new GeneratedClassFromXSD();
            var reader = XmlReader.Create(urlToService, settings);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(GeneratedClassFromXSD));
            obj = (GeneratedClassFromXSD)serializer.Deserialize(reader);

            reader.Close();
            return obj;
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
        {

        }



        public DataSet RunSample()
        {
            //Create the web request
            HttpWebRequest request
                = WebRequest.Create("http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=laptop&fl=EDP&store=pcmall&rows=25&start=0") as HttpWebRequest;

            //Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //    Load data into a dataset
                DataSet dsWeather = new DataSet();
                dsWeather.ReadXml(response.GetResponseStream());

                //Print dataset information
                PrintDataSet(dsWeather);
                return dsWeather;
            }
        }
        public static void PrintDataSet(DataSet ds)
        {
            //    // Print out all tables and their columns  
            foreach (DataTable table in ds.Tables)
            {
                Console.WriteLine("TABLE '{0}'", table.TableName);
                Console.WriteLine("Total # of rows: {0}", table.Rows.Count);
                Console.WriteLine("---------------------------------------------------------------");

                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine("- {0} ({1})", column.ColumnName, column.DataType.ToString());
                }  // foreach column  

                Console.WriteLine(System.Environment.NewLine);
            }  // foreach table  

            // Print out table relations  
            foreach (DataRelation relation in ds.Relations)
            {
                Console.WriteLine("RELATION: {0}", relation.RelationName);
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Parent: {0}", relation.ParentTable.TableName);
                Console.WriteLine("Child: {0}", relation.ChildTable.TableName);
                Console.WriteLine(System.Environment.NewLine);
            }  // foreach relation  
        }
        //----------------------END  */

        #endregion Errors

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}
 