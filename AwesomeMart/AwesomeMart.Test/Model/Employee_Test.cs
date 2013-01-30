using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeMart.Model;

namespace AwesomeMart.Test.Model
{
    [TestClass]
    public class Employee_Test
    {
        [TestMethod]
        public void can_add_new_employee()
        {
            Employee newEmployee = new Employee();
            AwesomeMartDbContext dbc = new AwesomeMartDbContext();

            dbc.Employees.Add(newEmployee);
            dbc.SaveChanges();

            Assert.IsTrue((from e in dbc.Employees
                           select e).Count() == 1);
        }
    }
}
