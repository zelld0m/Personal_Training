using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCDEMO.Models
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

    }
}