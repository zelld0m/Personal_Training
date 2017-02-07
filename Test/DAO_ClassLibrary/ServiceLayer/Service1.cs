using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    #region NEW
    //public class MyMessageInspector : IClientMessageInspector
    //{
    //    void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
    //    {
    //        Console.WriteLine("AfterReceiveReply called");
    //        throw new NotImplementedException();
    //    }

    //    object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
    //    {
    //        Console.WriteLine("BeforeSendRequest called");
    //        throw new NotImplementedException();
    //    }
    //}

    //public class SimpleEndpointBehavior : IEndpointBehavior
    //{
    //    public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    //    {
    //        // No implementation necessary
    //    }

    //    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    //    {
    //        clientRuntime.MessageInspectors.Add(new SimpleMessageInspector());
    //    }

    //    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    //    {
    //        // No implementation necessary
    //    }

    //    public void Validate(ServiceEndpoint endpoint)
    //    {
    //        // No implementation necessary
    //    }
    //}


    //public class SimpleBehaviorExtensionElement : BehaviorExtensionElement
    //{
    //    public override Type BehaviorType
    //    {
    //        get { return typeof(SimpleEndpointBehavior); }
    //    }

    //    protected override object CreateBehavior()
    //    {
    //        // Create the  endpoint behavior that will insert the message
    //        // inspector into the client runtime
    //        return new SimpleEndpointBehavior();
    //    }
    //}

    #endregion NEw 
    public class Service1 : IService1
    {
        #region Fixed
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        string IService1.GetData(int value)
        {
            throw new NotImplementedException();
        }
        CompositeType IService1.GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }
        #endregion Fixed
        
        #region Dummy
        Business b = new Business();
        void IService1.addDummy(string name)
        {
            b.name = name;
            b.insert_Dummy();
        }
        void IService1.deleteDummy(int ID)
        {
            b.id = ID;
            b.delete_Dummy(b.id);
        }
        void IService1.UpdateDummy(int ID, string Name)
        {
            b.id = ID;
            b.name = Name;
            b.update_Dummy(b.id);
        }
        DataSet IService1.SearchDummy(int ID_toSearch)
        {
            b.id = ID_toSearch;
            b.Search_dummy(b.id);
            DataSet ds = new DataSet();
            ds = b.Search_dummy(b.id);
            return ds;
        }
        DataSet IService1.viewALLDummy()
        {
            DataSet ds = new DataSet();
            ds = b.view_dummy();
            return ds;
            throw new NotImplementedException();
        }
        #endregion

        #region Authority
        DataSet IService1.viewAuthority()
        {
            DataSet ds = new DataSet();
            ds = b.view_Authority();
            return ds;
            throw new NotImplementedException();
        }
        void IService1.insertAuthority(string AuthorityName, int AccessLevel)
        {
            b.insert_Authority(AuthorityName, AccessLevel);
        }

        DataSet IService1.searchAuthority(int _ID)
        {
            DataSet ds = new DataSet();
            ds = b.search_Authority(_ID);
            return ds;
            throw new NotImplementedException();
        }

        void IService1.UpdateAuthority(int _id, int _AccessLevel, string _AuthorityName)
        {
            b.Update_Authority(_id, _AccessLevel, _AuthorityName);
            
        }

        void IService1.deleteAuthority(int _id)
        {
            b.delete_Authority(_id);
        }

        DataSet IService1.Validation(string _Name, string _AuthorityName)
        {

            DataSet ds = new DataSet();
            ds = b.validation(_Name,_AuthorityName);
            return ds;
            throw new NotImplementedException();
           
        }

        DataSet IService1.SearchBrand(String _BrandName)
        {
            DataSet ds = new DataSet();
            ds = b.Search_Brand(_BrandName);
            return ds;
            throw new NotImplementedException();
        }

        DataSet IService1.ViewALLProduct()
        {
            DataSet ds = new DataSet();
            ds = b.View_ALLProduct();
            return ds;
            throw new NotImplementedException();
            throw new NotImplementedException();
        }





        #endregion

    }



}