using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.


    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        void addDummy(String name);
        [OperationContract]
        void deleteDummy(int ID);
        [OperationContract]
        DataSet SearchDummy(int ID_toSearch);
        [OperationContract]
        void UpdateDummy(int ID, String Name);
        [OperationContract]
        DataSet viewALLDummy();


        [OperationContract]
        void insertAuthority(String AuthorityName, int AccessLevel);
        [OperationContract]
        DataSet viewAuthority();
        [OperationContract]
        DataSet searchAuthority(int _ID);
        [OperationContract]
        void UpdateAuthority(int _id, int _AccessLevel, String _AuthorityName);
        [OperationContract]
        void deleteAuthority(int _id);
        [OperationContract]
        DataSet Validation(String _Name, String _AuthorityName);
        [OperationContract]
        DataSet SearchBrand(String _BrandName);
        [OperationContract]
        DataSet ViewALLProduct();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceLayer.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
