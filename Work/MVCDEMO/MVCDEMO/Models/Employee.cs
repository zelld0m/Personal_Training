﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDEMO.Models
{
    [Table("tblEmployee")]          // This type of class needs to be the same as the Database
    public class Employee
    {
        public int EmployeeId { get; set; }       //  
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
    }
}