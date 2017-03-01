using MVCASPDOTNETCODEFIRST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCASPDOTNETCODEFIRST.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Northwind") { }
        public DbSet<DevTest> devtest { get; set; }

    }
}