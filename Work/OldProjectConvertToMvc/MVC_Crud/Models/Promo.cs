//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Crud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promo
    {
        public int PromoID { get; set; }
        public byte PromoAvailability_AvailabilityID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime DateLastModified { get; set; }
        public int ModifiedBy { get; set; }
        public bool ShowOnCap { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public string PromoText { get; set; }
        public byte PromoAvailabilityID { get; set; }
    }
}
