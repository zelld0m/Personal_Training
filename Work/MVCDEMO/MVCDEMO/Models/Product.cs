using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDEMO.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public String Store { get; set; }
        public string ProductDescription { get; set; }
        public String Price { get; set; }
        public string Imageurl { get; set; }
        public string Manufacturer { get; set; }
        public string Availability { get; set; }
    }
}