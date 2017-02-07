using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ShipR.Entities
{
	public class Store
	{    
		public int StoreID { get; set; } //store_ref
		public String StoreName { get; set; } //store

        public Store()
		{
            //no logic
		}
        		
	}
}
