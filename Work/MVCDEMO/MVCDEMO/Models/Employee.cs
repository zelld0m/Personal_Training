using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCDEMO.Models
{
    [Table("tblEmployee")]          // This type of class needs to be the same as the Database tablename
    public class Employee
    {

        public int EmployeeId { get; set; }       //  
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}