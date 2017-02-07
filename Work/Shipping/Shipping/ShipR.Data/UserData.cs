using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ShipR.Entities;


namespace ShipR.Data
{
	public class UserData
	{
		enum StoredProcedures
		{
			GTree_Calc
		}

		enum Parameters
		{
			Find1,
			Find2,
			Complete,
			Top,
			Parent1,
			Parent2
		}

		enum Fields
		{
			Node,
			Name_Path,
			Via,
			Parent
		}	

		public static DataSet GetAccessData(User user)
		{
			Database db = DatabaseFactory.CreateDatabase("Gman");
			DbCommand comm = db.GetStoredProcCommand(StoredProcedures.GTree_Calc.ToString());
			db.AddInParameter(comm, Parameters.Find1.ToString(), DbType.String, user.Application);
			db.AddInParameter(comm, Parameters.Find2.ToString(), DbType.String, user.Login);
			return db.ExecuteDataSet(comm);
		}

        //--------------xxxxxxxxxxxxxxxxxxx---------------------
        //public static DataSet GetAccessData(User user)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("Gman");
        //    DbCommand comm = db.GetStoredProcCommand(StoredProcedures.GTree_Calc.ToString());
        //    try
        //    {
        //        db.AddInParameter(comm, Parameters.Find1.ToString(), DbType.String, user.Application);
        //        db.AddInParameter(comm, Parameters.Find2.ToString(), DbType.String, user.Login);
        //        return db.ExecuteDataSet(comm);
        //    }
        //    catch(Exception ex)
        //    {
        //        return db.ExecuteDataSet(comm);
        //    }
        //}
    }
}
