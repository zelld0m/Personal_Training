using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCDEMO.Models;
using System.Web.Mvc;
namespace MVCDEMO.Controllers
{
   
    public class PersonController : Controller
    {
        public ActionResult PersonDetails(int id)
        {

            // by using this it can call data from database and see it on View 
             
            PersonContext personContext = new PersonContext();
            Person person = personContext.Persons.Single(emp => emp.P_Id == id);

            // Changed  so  it will retrieve from Database
            //Person person = new Person()
            //{
            //    P_Id = 101,
            //    FirstName = "aizel",
            //    LastName = "nunag",
            //    Username = "Anunag",
            //    Password = "oooooo"
            //};
            return View(person);
        }
    }
}
