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


        public DataContext db = new DataContext();    // Use this as database connection

        public ActionResult Index(int departmentId)
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employee.Where(emp =>emp.DepartmentId == departmentId).ToList();

            List<Employee> employees = db.employee.Where(emp => emp.DepartmentId == departmentId).ToList();

            return View(employees);
            
        }
        // GET: Employee
        public ActionResult Details(int id)
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //Employee employee = employeeContext.Employee.Single(emp => emp.EmployeeId == id);
            Employee employee = db.employee.Single(emp => emp.EmployeeId == id);



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

        public ActionResult ViewAllEmployee()
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employee.ToList();
            //--------------------------------------------------------------------
            List<Employee> employees = db.employee.ToList();
            return View(employees);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.employee.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    foreach (string key in formCollection.AllKeys)
        //    {
        //        Response.Write("Key " + key + "  ");
        //        Response.Write(formCollection[key]);
        //        Response.Write("<br/>");
        //    }
        //    return View();
        //}


    }
}