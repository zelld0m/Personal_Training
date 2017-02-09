using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Models;
namespace MVCDEMO.Controllers
{
    public class DepartmentController : Controller
    {


        private DataContext db = new DataContext();    // Use this as database connection
        // GET: Department
        public ActionResult Index()
        {

          //  EmployeeContext employeeContext = new EmployeeContext();
            List<Department> departments= db.Department.ToList();
            return View(departments);
        }
    }
}