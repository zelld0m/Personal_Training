using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCDEMO.Models
{
    // [MetadataType(typeof(EmployeeMetadata))]
    [Table("tblEmployee")]          // This type of class needs to be the same as the Database tablename
    public class Employee
    {
        public int EmployeeId { get; set; }       //  
                                                  //required removed To unEdit Name in Edit
        [DisplayAttribute(Name = "NAMETest")]  // USING DISPLAY ATTRIBUTE FROM MODEL
        public string Name { get; set; }
        [DisplayFormat(NullDisplayText = "Gender not Specified")]
        public string Gender { get; set; }
        [Required]
        //[ReadOnly(true)]   //Not working maybe on metadataType it will work  if not working  remove set is the same on getter:setter
     
        public string City { get; set; }
        [Required]/* [ScaffoldColumn(false)]*/   // NOT WORKING
        public int DepartmentId { get; set; }


        //TABLE ALTERED ADDED Salary,PersonalWebSite, DATEHIRE,EmailAddress,Photo,AlternateText
        #region NEW ADDED TABLE COLUMN

        //[Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true) ]  //    // fix format for dates
        public DateTime? HireDate { get; set; } // SUCCESS    ? nullable


        [Required]
        [DisplayFormat(NullDisplayText = "Salary not Specified" /*,DataFormatString ="{0:C}"*/ )]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")] // downside of this is to open a new window of all links
        [DisplayFormat(NullDisplayText = "website not Specified")]
        public string PersonalWebSite { get; set; }


        [DataType(DataType.EmailAddress)]       // this will open default email client  and open outlook
        public String EmailAddress { get; set; }
        public string Photo { get; set; }
        public String AlternateText { get; set; }

        #endregion
    }
   
}