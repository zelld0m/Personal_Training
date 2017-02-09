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



        public ActionResult Index(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employee.Where(emp =>emp.DepartmentId == departmentId).ToList();
            return View(employees);

        }
        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employee.Single(emp => emp.EmployeeId == id);
            #region Change To get Data From Database
            // Employee employee = new Employee()
            //{
            //    EmployeeId = 101,
            //    Name = "John",
            //    Gender = "Male",
            //    City = "London"
            //};
            #endregion
            return View(employee);
        }

        public ActionResult viewAllEmployee()
        {
       
           
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employee.ToList();
            return View(employees);
        }
        
    }
}