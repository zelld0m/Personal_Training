using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ShipR.Entities
{
    [Serializable]
	public class Shipping
	{    
		public int Code { get; set; }
		public String Display { get; set; }
        public String Type { get; set; }
        public String Delivery { get; set; }
        public int Macs_Code { get; set; }
        public String Notes1 { get; set; }
        public String Notes2 { get; set; }

        public Shipping()
		{
            //no logic
		}
        		
	}
}
