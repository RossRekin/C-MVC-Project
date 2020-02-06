using MVCFinalProject.DB;
using MVCFinalProject.Filters;
using MVCFinalProject.Models;
using MVCFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    [AdminCheckFilter]
    public class SmartphoneController : Controller
    {
        private SmartphoneDbContext db;

        public SmartphoneController()
        {
            this.db = new SmartphoneDbContext();
        }

        public ActionResult Index()
        {
            List<Smartphone> phones = this.db.Smartphones.ToList();
            return View(phones);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Smartphone phone)
        {
            this.db.Smartphones.Add(phone);
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Smartphone phone = this.db.Smartphones
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (phone == null)
            {
                return Redirect("404");
            }

            return View(phone);
        }

        [HttpPost]
        public ActionResult Edit(Smartphone phone)
        {
            Smartphone currentPhone = this.db.Smartphones.
                Where(x => x.Id == phone.Id).
                FirstOrDefault();
            currentPhone.Title = phone.Title;
            currentPhone.Price = phone.Price;
            currentPhone.Description = phone.Description;
            this.db.Smartphones.Add(currentPhone);
            this.db.Entry(currentPhone).State = EntityState.Modified;

            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            ViewData["error"] = true;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Smartphone phone = this.db.Smartphones.
                   Where(x => x.Id == id).
                   FirstOrDefault();

            if (phone == null)
            {
                return Redirect("404");
            }
            this.db.Smartphones.Add(phone);
            this.db.Entry(phone).State = EntityState.Deleted;
            int result = this.db.SaveChanges();

            if (result==1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}