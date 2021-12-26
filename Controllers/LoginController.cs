using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RTraders.Models;

namespace RTraders.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        /*
        public ActionResult AuthenticateUser(string username, string password = "")
        {
            JsonResult result = new JsonResult();
            if (username == "srini" && password == "srini")
            {
               
                return Json("Authenticated", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Failed", JsonRequestBehavior.AllowGet);
        }
        */

        [HttpPost]
        public ActionResult Authenticate(FormCollection form)
        {
            string username = form["txtusername"].Trim().ToString();
            string password = form["txtpassword"].Trim().ToString();
           
            JsonResult result = new JsonResult();
            DBoperations ops = new DBoperations();
            int res = ops.authenticateuser(username, password);
            if (res != 0)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", new {msg = "Invalid User" });
        }
    }
}