using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
    public class DataAccess
    {
        SqlConnection con = new SqlConnection("Data Source=DMNLANUNAG;Initial Catalog=Registration;Integrated Security=True");
        #region  DB_Dummy
        public DataSet view_Dummy()
        { 
            SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "Select * from dummy";
            SqlDataAdapter sda = new SqlDataAdapter("SelectALL_Dummy", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        public void insert_Dummy(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Insert_Dummy";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_Dummy(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update_Dummy";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Dummy(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Delete_Dummy";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Search_dummy(SqlCommand cmd,int _id)
        {
            String query = " Select * from dummy where ID = '" + _id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        #endregion DB_DummyEnd
        #region DB_Authority
        public DataSet view_Authority()
        {
            SqlCommand cmd = con.CreateCommand();
            String query = "Select * from AuthorityLevel";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        public void insert_Authority(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Insert_Authority";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Search_Authority(SqlCommand cmd,int _id)
        {
            String query = "Select * From AuthorityLevel where A_ID = '" +_id +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        public void Update_Authority(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update_Authority";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Authority(SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Delete_Authority";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion DB_AuthorityEnd
        public DataSet validation(SqlCommand cmd , String _name , String _AuthorityName)
        {
    
            String query = "select * from Dummy as D inner join authoritylevel as A on d.ID = A.A_Id where Name = '"+ _name +"' AND AuthorityName = '"+ _AuthorityName+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        public DataSet Search_Brand(SqlCommand cmd, String _BrandName)
        {
            String query = "select * from Product where brand = '" + _BrandName+"'" ;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
        public DataSet View_ALLProduct()
        {
            SqlCommand cmd = con.CreateCommand();
            String query = "Select * from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
    }
}



        
