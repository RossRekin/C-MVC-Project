using MVCFinalProject.DB;
using MVCFinalProject.Filters;
using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    [AdminCheckFilter]
    public class LaptopController : Controller
    {
        private LaptopDBContext db;
        public LaptopController()
        {
            this.db = new LaptopDBContext();
        }
        public ActionResult Index()
        {
            List<Laptop> laptops = db.Laptops.ToList();
            return View(laptops);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Laptop laptop)
        {
            this.db.Laptops.Add(laptop);
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Laptop laptop = this.db.Laptops
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (laptop == null)
            {
                return Redirect("404");
            }
            return View(laptop);
        }

        [HttpPost]
        public ActionResult Edit(Laptop laptop)
        {
            Laptop currentLaptop = this.db.Laptops
                .Where(x => x.Id == laptop.Id)
                .FirstOrDefault();
            currentLaptop.Title = laptop.Title;
            currentLaptop.Description = laptop.Description;
            currentLaptop.Price = laptop.Price;
            currentLaptop.Os = laptop.Os;

            this.db.Laptops.Add(currentLaptop);
            this.db.Entry(currentLaptop).State = EntityState.Modified;
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }

            //TODO: Show msg error
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Laptop laptop = this.db.Laptops
               .Where(x => x.Id == id)
               .FirstOrDefault();
            if (laptop == null)
            {
                return Redirect("404");
            }
            this.db.Laptops.Add(laptop);
            this.db.Entry(laptop).State = EntityState.Deleted;
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}