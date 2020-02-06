using MVCFinalProject.DB;
using MVCFinalProject.Models;
using MVCFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private SmartphoneService service;
        private LaptopDBContext db;

        public HomeController()
        {
            this.service = new SmartphoneService();
            this.db = new LaptopDBContext();
        }

        public ActionResult Index()
        {
            List<Laptop> laptops = db.Laptops.ToList();
            List<Smartphone> phones = this.service.GetSmartphones();
            ProductViewModel productVM = new ProductViewModel()
            {
                Laptops = laptops,
                Smartphones = phones
            };
            
            return View(productVM);
        }


    }
}