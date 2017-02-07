using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ShipR.Entities
{
	public class Discount
	{    
		public int DiscountTypeID { get; set; }
		public String DiscountTypeDesc { get; set; }
        public String DetailedDesc { get; set; }

        public Discount()
		{
            //no logic
		}
        		
	}
}
