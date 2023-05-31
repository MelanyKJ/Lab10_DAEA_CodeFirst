using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace CodeFirst.Models
{
    public class ContextDemo : DbContext
    {
        public ContextDemo() : base("name = MyContextDB") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }

    }
}