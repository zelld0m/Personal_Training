using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        [HandleError]
        public ActionResult Index()
        {
            return View("Error");
        }
        [HandleError]
        public ActionResult Error400()
        {
            Response.StatusCode = 400;
            return View("Error400");
        }
        [HandleError]
        public ActionResult Error404()  // File Not Found
        {
            Response.StatusCode = 404;
            return View("Error404");
        }

        [HandleError]
        public ActionResult Error500()  // File Not Found
        {
            Response.StatusCode = 500;
            return View("Error500");
        }
    }
}