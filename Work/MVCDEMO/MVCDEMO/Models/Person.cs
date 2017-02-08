﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDEMO.Models
{
    [Table("Persons")]
    public class Person
    {
        
        public int P_Id { get; set; }
        public string LastName { get; set; }
        public string FirstName{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

    }
}