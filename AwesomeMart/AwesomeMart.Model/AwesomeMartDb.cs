using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AwesomeMart.Enumerations;

namespace AwesomeMart.Model
{
    /// <summary>
    /// DbContext is used to generate the database... 
    /// You also query against this class.
    /// </summary>
    public class AwesomeMartDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
