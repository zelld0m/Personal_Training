using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Models;

namespace MVCDEMO.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employee.Single(emp => emp.EmployeeId == id);

            //Change To get Data From Database
                // Employee employee = new Employee()
                //{
                //    EmployeeId = 101,
                //    Name = "John",
                //    Gender = "Male",
                //    City = "London"
                //};
            return View(employee);
        }
    }
}