using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Models;
using System.Net;
using System.Data.Entity;

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

        #region CRUD
        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ViewAllEmployee");
            }
            return View(employee);
        }
        #endregion Create End

        #region Edit
        
        public ActionResult Edit(int? id)  // DATA REQUEST TO BE SHOWN ON EDIT PAGE
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;  // entityState is used for Delete ,update
                db.SaveChanges();
                return RedirectToAction("ViewAllEmployee");
            }
            return View(employee);
        }

        #endregion Edit End

        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employeesxx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.employee.Find(id);
            db.employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion Delete End

        #endregion CRUD END


    }
}