using MVCFinalProject.Models;
using MVCFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user,string cPassword)
        {
            bool isValid = true;
            if (user.Password != cPassword)
            {
                isValid = false;
            }
            if (user.Password.Length < 3)
            {
                isValid = false;
            }
            if (isValid)
            {
                var us = new UserService();
                bool result = us.Register(user);
                if (result)
                {
                    return RedirectToAction("Index", "Login");
                }
                ViewData["existingUser"] = true;
                return View();
            }

            ViewData["errors"] = true;
            return View();
        }
    }
}