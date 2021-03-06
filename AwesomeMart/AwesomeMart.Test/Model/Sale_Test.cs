﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeMart.Model;
using AwesomeMart.Enumerations;

namespace AwesomeMart.Test.Model
{
    [TestClass]
    public class Sale_Test
    {

        [TestMethod]
        public void can_have_more_than_one_product_in_sale()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            Sale sale = new Sale();
            sale.Employee = (from e in context.Employees
                             where e.Name.Equals("John Davis")
                             select e).FirstOrDefault();

            sale.Customer = (from c in context.Customers
                             where c.Name.Equals("Ricky Ricardo")
                             select c).FirstOrDefault();

            sale.Products = new List<Product>();

            foreach (Product p in context.Products)
            {
                sale.Products.Add(p);
            }

            context.Sales.Add(sale);
            context.SaveChanges();

            Assert.IsTrue(1 < sale.Products.Count());
        }

        [TestMethod]
        public void relationships_work_between_sales_and_employees()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            Sale sale = new Sale();
            sale.Employee = (from e in context.Employees
                             where e.Name.Equals("John Davis")
                             select e).FirstOrDefault();

            sale.Customer = (from c in context.Customers
                             where c.Name.Equals("Ricky Ricardo")
                             select c).FirstOrDefault();

            sale.Products = new List<Product>();

            foreach (Product p in context.Products)
            {
                sale.Products.Add(p);
            }

            context.Sales.Add(sale);
            context.SaveChanges();

            Employee employee = context.Employees.Where(e => e.Name.Equals("John Davis")).FirstOrDefault();


            Assert.AreEqual(sale.Employee.ID, employee.ID);
        }

        [TestMethod]
        public void lazy_loading_works_between_sales_and_employee()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            
            Sale sale = (from s in context.Sales
                    select s).FirstOrDefault();

            Assert.IsTrue(null == sale.Employee.Department);
        }
    }
}
