using System;
using System.Collections.Generic;
using System.Web;

namespace ShipR.Entities
{
	public class User
	{
		enum Rights {
			Read,
			Write
		}
        #region  Accessor 1

        private bool _allowedRead = false;                  //  this kind of accessor is used   because of the Default Value required
        private bool _allowedWrite = false;

        public bool AllowedRead
        {
            get { return _allowedRead; }
            set { _allowedRead = value; }
        }
        public bool AllowedWrite
        {
            get { return _allowedWrite; }
            set { _allowedWrite = value; }
            
        }
        
        #endregion

        #region Accessor 2

        public string Application { get; set; }             // But for simplicity use this kind of ACCESSOR         
        public string Login { get; set; }

        #endregion
        public User()
		{
		}
	}
}
