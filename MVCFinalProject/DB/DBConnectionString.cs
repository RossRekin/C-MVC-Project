using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.DB
{
    public class DBConnectionString
    {
        public static string Get()
        {
            return $"Server={Environment.MachineName};Database=MobileMallDb;Trusted_Connection=True;";
            
        }
    }
}