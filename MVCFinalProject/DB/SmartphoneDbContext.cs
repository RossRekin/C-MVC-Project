using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFinalProject.DB
{
    public class SmartphoneDbContext : DbContext
    {
        public SmartphoneDbContext() : base(DBConnectionString.Get())
        {

        }

        public DbSet<Smartphone> Smartphones { get; set; }
    }

   
}