using MVCFinalProject.Models;
using MVCFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            UserService us = new UserService();
            User u = us.LoginAttempt(user);
            if (u == null)
            {
                ViewData["wrongUser"] = true;
                return View();
            }
            Session["user"] = u;

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}