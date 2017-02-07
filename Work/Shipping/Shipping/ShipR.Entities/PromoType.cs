using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ShipR.Entities
{
	public class PromoType
	{    
		public int PromoTypeID { get; set; }
		public String PromoTypeDesc { get; set; }


        public PromoType()
		{
            //no logic
		}
        		
	}
}
