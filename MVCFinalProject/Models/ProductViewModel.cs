using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class ProductViewModel
    {
        public List<Smartphone> Smartphones { get; set; }
        public List<Laptop> Laptops { get; set; }
    }
}