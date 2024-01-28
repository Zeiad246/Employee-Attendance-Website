using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterEmployee.Models;

namespace RegisterEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private AttendanceEntities empDB = new AttendanceEntities();   
        // GET: Employee
        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employee(Employee employee)
        {
            if (Session["UsernameSS"] != null)
            {
                //List<SelectListItem> employees = new List<SelectListItem>();
                //foreach (Employee emp in empDB.Employees)
                //{
                //    SelectListItem empItem = new SelectListItem
                //    {
                //        Text = emp.employee_name,
                //        Value = emp.employee_cardID.ToString(),
                //    };


                //    employees.Add(empItem);

                    
                //}

                //ViewBag.EmployeeNames = employees;

                return View();
            }

            

            

            ViewBag.Notification = "Please Login First";
            return RedirectToAction("LogIn", "Home");

        }
    }
}