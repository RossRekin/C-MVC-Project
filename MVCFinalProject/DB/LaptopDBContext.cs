using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFinalProject.DB
{
    public class LaptopDBContext : DbContext
    {

        public LaptopDBContext() : base(DBConnectionString.Get())
        {

        }

        public DbSet<Laptop> Laptops { get; set; }

    }
}