using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
namespace BusinessLayer
{
    public class Business
    {
        #region Declaration
        DataAccess da = new DataAccess();
        public int id { get; set; }
        public String name { get; set; }
        SqlCommand cmd = new SqlCommand();
        #endregion Declaration
        #region Crud_Dummy
        public DataSet view_dummy() //  view
        {
            return da.view_Dummy();
        }
        public void insert_Dummy()   //Insert
        {
            cmd.Parameters.AddWithValue("@name", name);//
            da.insert_Dummy(cmd);       // Method created in dataaccesslayer
        }
        public void update_Dummy(int _id)// Update
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            da.update_Dummy(cmd);

        }
        public void delete_Dummy(int _id)   //Delete
        {
            cmd.Parameters.AddWithValue("@id", id);
            da.Delete_Dummy(cmd);
        }
        public DataSet Search_dummy(int _id)   //Search
        {

            return da.Search_dummy(cmd, _id);


        }
        #endregion Crud_DummyEnd


        #region Crud_Authority
        public void insert_Authority(String AuthorityName,int AccessLevel)
        {
            cmd.Parameters.AddWithValue("@AuthorityName", AuthorityName);
            cmd.Parameters.AddWithValue("@AccessLevel", AccessLevel);
            da.insert_Authority(cmd);

        }
        public DataSet view_Authority()
        {
            return da.view_Authority();
        }
        public DataSet search_Authority(int _id)
        {
            return da.Search_Authority(cmd, _id);
        }
        public void Update_Authority(int _id,int _AccessLevel,String _AuthorityName)
        {
            cmd.Parameters.AddWithValue("@AccessLevel", _AccessLevel);
            cmd.Parameters.AddWithValue("@AuthorityName", _AuthorityName);
            cmd.Parameters.AddWithValue("@id", _id);
            da.Update_Authority(cmd);
        }
        public void delete_Authority(int _id)
        {
            cmd.Parameters.AddWithValue("@A_id", _id);
            da.Delete_Authority(cmd);
        }
        #endregion Crud_Authority

        public DataSet validation(String _name,String _AuthorityName)
        {
           return da.validation(cmd, _name, _AuthorityName);
        }
        public DataSet Search_Brand(String _BrandName)
        {
            return da.Search_Brand(cmd, _BrandName);
        }
        public DataSet View_ALLProduct()
        {
            return da.View_ALLProduct();
        }
    }

}
