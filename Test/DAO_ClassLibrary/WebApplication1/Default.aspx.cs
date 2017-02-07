using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            String filename = Server.MapPath("StudentData.xml");
        if(File.Exists(filename)==true)
            {
                //addnew Record
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(Server.MapPath("StudentData.xml"));

                XmlElement Student = xdoc.CreateElement("Student");

                // this code for Creatign  a new Element to find the text for that element 
                XmlElement ID = xdoc.CreateElement("ID");
                XmlText xmlID = xdoc.CreateTextNode(txtID.Text);

                XmlElement FirstName = xdoc.CreateElement("FirstName");
                XmlText xmlFirstName = xdoc.CreateTextNode(txtFirstName.Text);
                XmlElement LastName = xdoc.CreateElement("LastName");
                XmlText xmlLastName = xdoc.CreateTextNode(txtLastName.Text);
                XmlElement City = xdoc.CreateElement("City");
                XmlText xmlCity = xdoc.CreateTextNode(ddlCity.SelectedItem.Text);
                XmlElement Gender = xdoc.CreateElement("Gender");
                XmlText xmlGender = xdoc.CreateTextNode(rbGender.SelectedItem.Text);
                XmlElement Pincode = xdoc.CreateElement("Pincode");
                XmlText xmlPincode = xdoc.CreateTextNode(txtPincode.Text);
                XmlElement MobileNo = xdoc.CreateElement("MobileNo");
                XmlText xmlMobileNo = xdoc.CreateTextNode(txtMobileNo.Text);

                // TELL EACH ELEMENT WHAT IS THEIR TEXT LIKE AS under
                ID.AppendChild(xmlID);
                FirstName.AppendChild(xmlFirstName);
                LastName.AppendChild(xmlLastName);
                City.AppendChild(xmlCity);
                Gender.AppendChild(xmlGender);
                Pincode.AppendChild(xmlPincode);
                MobileNo.AppendChild(xmlMobileNo);
                //now append this to Student Element

                Student.AppendChild(ID);
                Student.AppendChild(FirstName);
                Student.AppendChild(LastName);
                Student.AppendChild(City);
                Student.AppendChild(Gender);
                Student.AppendChild(Pincode);
                Student.AppendChild(MobileNo);

                // now append the whole student into the document or file

                xdoc.DocumentElement.AppendChild(Student);

                //SAVE
                xdoc.Save(Server.MapPath("StudentData.xml"));


            }
        else
            {
                //Create new file and structure
                XmlTextWriter xtw = new XmlTextWriter(filename, null);


                xtw.WriteStartDocument();
                xtw.WriteStartElement("Students");
                xtw.WriteStartElement("Student");

                xtw.WriteElementString("ID", txtID.Text);
                xtw.WriteElementString("FirstName", txtFirstName.Text);
                xtw.WriteElementString("LastName", txtLastName.Text);
                xtw.WriteElementString("City", ddlCity.Text);
                xtw.WriteElementString("Gender", rbGender.SelectedItem.Text);
                xtw.WriteElementString("Pincode", txtPincode.Text);
                xtw.WriteElementString("MobileNo", txtMobileNo.Text);


                // closeStudent and Students
                xtw.WriteEndElement();

                xtw.WriteEndElement();

                xtw.WriteEndDocument();

                // Close this Stream

                xtw.Close();



            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}