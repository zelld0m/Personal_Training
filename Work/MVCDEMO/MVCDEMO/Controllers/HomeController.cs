using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Countries()
        {

            // THIS IS NOT THE BEST PRACTICE  
            //it just shows that it is possible to use 
            //this kind of coding
            ViewBag.Countries = new List<string>()
            {
                "INDIA",
                "US",
                "CANADA"
            };
            return View();

            // THIS IS NOT THE BEST PRACTICE  
            //it just shows that it is possible to use 
            //this kind of coding

            //ViewData["Countries"] = new List<string>()
            //{
            //    "India",
            //    "Us",
            //    "Canada"
            //};
            //return View();
        }
    }
}