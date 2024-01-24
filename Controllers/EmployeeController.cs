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
        AttendanceEntities empDB = new AttendanceEntities();   
        // GET: Employee
        [HttpGet]
        public ActionResult EmployeeDataEditor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeDataEditor(Employee employee)
        {
            
            return View();
        }
    }
}