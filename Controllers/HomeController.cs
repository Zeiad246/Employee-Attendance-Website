using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterEmployee.Models;

namespace RegisterEmployee.Controllers
{
    public class HomeController : Controller
    {
        
        AttendanceEntities userDB = new AttendanceEntities();

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin userLogin)
        {

            var checkLogin =
                userDB.UserLogins.Where(x => x.username_log.Equals(userLogin.username_log)
                && x.password_log.Equals(userLogin.password_log)).FirstOrDefault();

            if (checkLogin != null)
            {

                Session["IDSS"] = userLogin.id.ToString();
                Session["UsernameSS"] = userLogin.username_log.ToString();

                return RedirectToAction("Employee");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Employee()
        {
            if (Session["UsernameSS"] != null)
            {
                return View();
            }
            
            
                ViewBag.Notification = "Please login FIrst";
            
            return RedirectToAction("Index");
            
        }
    }
}
