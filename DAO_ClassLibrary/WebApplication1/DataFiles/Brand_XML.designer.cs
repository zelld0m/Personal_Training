// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.41537 Microsoft Reciprocal License (Ms-RL) 
//    <NameSpace>WebApplication1</NameSpace>
//<Collection>List</Collection>
//<codeType>CSharp</codeType>
//<EnableDataBinding>False</EnableDataBinding>
//<EnableLazyLoading>False</EnableLazyLoading>
//<TrackingChangesEnable>False</TrackingChangesEnable>
//<GenTrackingClasses>False</GenTrackingClasses>
//<HidePrivateFieldInIDE>False</HidePrivateFieldInIDE>
//<EnableSummaryComment>False</EnableSummaryComment>
//<VirtualProp>False</VirtualProp>
//<IncludeSerializeMethod>False</IncludeSerializeMethod
//><UseBaseClass>False</UseBaseClass>
//<GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod>
//<GenerateDataContracts>False</GenerateDataContracts>
//<CodeBaseTag>Net20</CodeBaseTag>
//<SerializeMethodName>Serialize</SerializeMethodName>
//<DeserializeMethodName>Deserialize</DeserializeMethodName>
//<SaveToFileMethodName>SaveToFile</SaveToFileMethodName>
//<LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName>
//<GenerateXMLAttributes>False</GenerateXMLAttributes>
//<OrderXMLAttrib>False</OrderXMLAttrib>
//<EnableEncoding>False</EnableEncoding>
//<AutomaticProperties>False</AutomaticProperties>
//<GenerateShouldSerialize>False</GenerateShouldSerialize>
//<DisableDebug>False</DisableDebug>
//<PropNameSpecified>Default</PropNameSpecified>
//<Encoder>UTF8</Encoder>
//<CustomUsings></CustomUsings>
//<ExcludeIncludedTypes>False</ExcludeIncludedTypes>
//<EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace WebApplication1
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Xml;
    using System.IO;
    using System.Text;

    public partial class response
    {
       // Deserialization
        static XmlSerializer serializer = new XmlSerializer(typeof(response));
        StreamReader sr = new StreamReader("Brand_XML.xml");


        //static XmlSerializer serializer = new XmlSerializer(typeof(response));
        //response resultingMessage = (response)serializer.Deserialize(new XmlTextReader("Brand_XML.xml"));


        //XmlSerializer serializer = new XmlSerializer(typeof(msg));
        //MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(inputString));
        //msg resultingMessage = (msg)serializer.Deserialize(memStream);


        //XmlSerializer serializer = new XmlSerializer(typeof(response));
        //StringReader rdr = new StringReader(inputString);
        //response resultingMessage = (response)serializer.Deserialize(rdr);


        private List<object> itemsField;

        public response()
        {
            this.itemsField = new List<object>();
        }

        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    public partial class responseLst
    {

        private List<responseLstInt> intField;

        private List<responseLstLst> lstField;

        private List<responseLstRule> search_rulesField;

        private string nameField;

        public responseLst()
        {
            this.search_rulesField = new List<responseLstRule>();
            this.lstField = new List<responseLstLst>();
            this.intField = new List<responseLstInt>();
        }

        public List<responseLstInt> @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }

        public List<responseLstLst> lst
        {
            get
            {
                return this.lstField;
            }
            set
            {
                this.lstField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayItemAttribute("rule", IsNullable = false)]
        public List<responseLstRule> search_rules
        {
            get
            {
                return this.search_rulesField;
            }
            set
            {
                this.search_rulesField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    public partial class responseLstInt
    {

        private string nameField;

        private ushort valueField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public partial class responseLstLst
    {

        private List<object> itemsField;

        private string nameField;

        public responseLstLst()
        {
            this.itemsField = new List<object>();
        }

        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    public partial class responseLstLstArr
    {

        private List<string> strField;

        private string nameField;

        public responseLstLstArr()
        {
            this.strField = new List<string>();
        }

        public List<string> str
        {
            get
            {
                return this.strField;
            }
            set
            {
                this.strField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    public partial class responseLstLstLst
    {

        private List<responseLstLstLstInt> intField;

        private string nameField;

        public responseLstLstLst()
        {
            this.intField = new List<responseLstLstLstInt>();
        }

        public List<responseLstLstLstInt> @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    public partial class responseLstLstLstInt
    {

        private string nameField;

        private uint valueField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public partial class responseLstLstStr
    {

        private string nameField;

        private string valueField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public partial class responseLstRule
    {

        private string idField;

        private string nameField;

        private bool activeField;

        private string typeField;

        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public bool active
        {
            get
            {
                return this.activeField;
            }
            set
            {
                this.activeField = value;
            }
        }

        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    public partial class responseResult
    {

        private List<responseResultDoc> docField;

        private string nameField;

        private uint numFoundField;

        private byte startField;

        public responseResult()
        {
            this.docField = new List<responseResultDoc>();
        }

        public List<responseResultDoc> doc
        {
            get
            {
                return this.docField;
            }
            set
            {
                this.docField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public uint numFound
        {
            get
            {
                return this.numFoundField;
            }
            set
            {
                this.numFoundField = value;
            }
        }

        public byte start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }
    }

    public partial class responseResultDoc
    {

        private responseResultDocInt intField;

        public responseResultDoc()
        {
            this.intField = new responseResultDocInt();
        }

        public responseResultDocInt @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }
    }

    public partial class responseResultDocInt
    {

        private string nameField;

        private uint valueField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

}
