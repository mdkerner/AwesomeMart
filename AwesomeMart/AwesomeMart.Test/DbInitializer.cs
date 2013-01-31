using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeMart.Model;
using AwesomeMart.Enumerations;

namespace AwesomeMart.Test
{
    public class DbInitializer
    {
        public static AwesomeMartDb EmptyAwesomeMartDbContext
        {
            get
            {
                AwesomeMartDb dbc = new AwesomeMartDb();
                dbc.Database.Delete();
                dbc.Database.Create();
                return dbc;
            }
        }

        public static AwesomeMartDb SeededAwesomeMartDbContext
        {
            get
            {
                return Seed(EmptyAwesomeMartDbContext);
            }
        }

        private static AwesomeMartDb Seed(AwesomeMartDb context)
        {
             context.Employees.Add(new Employee
            {
                Name = "John Davis",
                Position = Position.Cashier,
                PayType = Enumerations.PayType.Hourly,
                PayRate = 10.25,
                Address = "1234 Some Street, Onett CA, 93123",
                Phone = "233-433-2907"
            });

             context.Customers.Add(new Customer
             {
                Name = "Ricky Ricardo",
                Address = "54321 Different Road, Twoson, AZ, 43667",
                Phone = "678-555-1254"
             });

            context.Products.Add(new Product
            {
                Name = "Snuggie, Blue",
                Price = 24.99
            });

            context.Products.Add(new Product
            {
                Name = "Snuggie, Blue",
                Price = 24.99
            });

            context.Products.Add(new Product
            {
                Name = "Snuggie, Grey",
                Price = 24.99
            });

            context.Products.Add(new Product
            {
                Name = "Slap Chop",
                Price = 19.99
            });

            context.Products.Add(new Product
            {
                Name = "Slap Chop",
                Price = 19.99
            });

            context.Products.Add(new Product
            {
                Name = "Oxyclean, 24oz",
                Price = 9.99
            });

            context.Products.Add(new Product
            {
                Name = "Oxyclean, 24oz",
                Price = 9.99
            });

            context.Products.Add(new Product
            {
                Name = "Oxyclean, 24oz",
                Price = 9.99
            });

            context.Products.Add(new Product
            {
                Name = "Oxyclean, 24oz",
                Price = 9.99
            });

            context.Products.Add(new Product
            {
                Name = "Oxyclean, 24oz",
                Price = 9.99
            });

            context.SaveChanges();

            return context;
        }
    }
}
