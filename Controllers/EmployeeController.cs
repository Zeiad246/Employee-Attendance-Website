using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            if (Session["UsernameSS"] != null)
            {

                string constr = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ToString();
                SqlConnection _connection = new SqlConnection(constr);
                SqlDataAdapter _adapter = new SqlDataAdapter("Select * From Employee", constr);
                DataTable _dataTable = new DataTable();
                _adapter.Fill(_dataTable);
                ViewBag.EmployeeList = ToSelectList(_dataTable, "employee_ID", "employee_name");

                return View();
            }

            ViewBag.Notification = "Please Login First";
            return RedirectToAction("LogIn", "Home");
            
        }

        [HttpPost]
        public ActionResult Employee(Employee employee)
        {

            var emps = employee.employee_ID;

                
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


                return View(employee);
            

        }


        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

    }
}