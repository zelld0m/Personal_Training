using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCDEMO.Models
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Employee> employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        //public virtual DbSet<Product> Product { get; set; }
        public DataContext() : base("DataContextFromWebConfig")   // base got from Web.Config name of connection String
        {

        }
    }
}