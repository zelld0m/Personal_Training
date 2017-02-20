using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Models;
using System.Net;
using System.Data.Entity;
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

        //put the int? on an action means that you can have the route satisfied without id( in that case, MVC will pass null)
        public ActionResult Details(string id)  // id turns into String 
        {

            ViewBag.DepartmentIdNaming = new SelectList(db.Department, "id","Name","1"); // use this on  displaying department name

            List<Employee> employees = new List<Employee>();
            List<int> idInt = new List<int>();
            List<string> idString = new List<string>(id.Split('-'));  // to change seperator change  comma "  ,  "   to  "  -  " 
            string nullIds = "ID Does Not Exist : ";
            for (int i = 0; i <= idString.Count - 1; i++)
            {
                idInt.Add(Convert.ToInt32(idString[i]));
            }
            for (int i = 0; i <= idInt.Count - 1; i++)
            {
                if (db.employee.Find(idInt[i]) != null)
                {
                    employees.Add(db.employee.Find(idInt[i]));
                }
                else // not working for now 
                {
                    nullIds +=  Convert.ToString((idInt[i])) + " , ";  // Find how to return nullIds to view hahaha
                }
            }
            if(nullIds != "ID Does Not Exist : ")
            {
                ViewData["nullIds"] = " "+nullIds ;
            }
            if (employees == null ) // not working well
            {
                return RedirectToAction("NotFound", "Error", "Error");
            }
            return View(employees);
        }
        public ActionResult Details2(int? id, int? id2, int? id3, int? id4, int? id5)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   // this will redirect to badrequest 
            //}
            //Employee employee = db.employee.Find(id);
            List<Employee> employees = new List<Employee>();

            if (db.employee.Find(id) != null)
            {
                employees.Add(db.employee.Find(id));
            }

            if (db.employee.Find(id2) != null)
            {
                employees.Add(db.employee.Find(id2));
            }
            if (db.employee.Find(id3) != null)
            {
                employees.Add(db.employee.Find(id3));
            }
            if (db.employee.Find(id4) != null)
            {
                employees.Add(db.employee.Find(id4));
            }
            if (db.employee.Find(id5) != null)
            {
                employees.Add(db.employee.Find(id5));
            }
            if (employees == null)
            {
                return RedirectToAction("NotFound", "Error", "Error");
            }
            return View(employees);
        }
        #region CRUD

        #region Create
        [HttpGet]
        public ActionResult Create()
        { 
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "Name", "1");// dropdownlist Success (Used on Create View)
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId,HireDate,Salary,PersonalWebSite,EmailAddress,Photo,AlternateText")] Employee employee)
            public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId,HireDate")] Employee employee)
        //        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (String.IsNullOrEmpty(employee.Name) || string.IsNullOrWhiteSpace(employee.Name))
            {
                ModelState.AddModelError("Name", "The Name Field is Required");
            }
              TryUpdateModel(employee);    // use tryUpdate to verify  
            if (ModelState.IsValid)       // to verify
            {

                db.employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ViewAllEmployee");
            }
            return View(employee);
        }
        #endregion Create End

        #region Read
        public ActionResult ViewAllEmployee()
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employee.ToList();
            //--------------------------------------------------------------------
            Employee employee; // as person

            List<Employee> employees = db.employee.ToList();
            for (int i = 0;i <= 10;i++)
            {

            }
            //Employee employeeFromDb =  db.employee.Single(x => x.EmployeeId == employee.);
            //if(employeeFromDb.Salary == null)
            //{
            //    employeeFromDb.Salary = 1;
            //}
          
            return View(employees);
        }
        #endregion

        #region Update

        public ActionResult Edit(int? id)  // DATA REQUEST TO BE SHOWN ON EDIT PAGE     ? is for null acceptance entry 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return RedirectToAction("NotFound", "Error", "Error");
                //return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]  // httpPost is for saving or implementing the data that has beed initiated
        // [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind( /*Exclude ="Name"*/Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            //Employee employeeFromDb = db.employee.Single(x => x.EmployeeId == employee.EmployeeId);

            //employeeFromDb.Gender = employee.Gender;
            //employeeFromDb.City = employee.City;
            //employeeFromDb.DepartmentId = employee.DepartmentId;
            //employee.Name = employeeFromDb.Name;

            if (String.IsNullOrEmpty(employee.Name) || string.IsNullOrWhiteSpace(employee.Name))
            {
                ModelState.AddModelError("Name", "The Name Field is Required");
            }

            if (ModelState.IsValid)// to verify
            {
                //   db.ObjectStateManager.ChangeObjectState(employeeFromDb, EntityState.Modified);   used on Entity framwork datamodel
                db.Entry(employee).State = EntityState.Modified;  // entityState is used for Delete ,update
                db.SaveChanges();
                return RedirectToAction("ViewAllEmployee");
            }
            return View(employee);
        }

        #endregion Update End

       #region Delete
        //public ActionResult Delete(int? id)  // this is applicable on Delete view to show/get the details from view
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.employee.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        // POST: Employeesxx/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.employee.Find(id);
            db.employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("ViewAllEmployee");
        }
        #endregion Delete End 
        #endregion CRUD END

    }
}