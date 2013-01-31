using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeMart.Model;

namespace AwesomeMart.Test.Model
{
    [TestClass]
    public class Department_Test
    {

        [TestMethod]
        public void can_set_default_values_in_object_constructor()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Department department = new Department();
            Assert.AreEqual("Sales", department.Name);
            Assert.IsNotNull(department.Employees);

        }

        [TestMethod]
        public void non_icollection_does_lazy_load()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            context.Employees.Where(e=>e.Name.Equals("John Davis")).FirstOrDefault().Department = new Department();
            context.SaveChanges();

            Department department = context.Employees.Where(e => e.Name.Equals("John Davis")).FirstOrDefault().Department;
            context.Database.Connection.Close();

            Assert.IsNotNull(department.Employees.Where(e=>e.Name.Equals("John Davis")).FirstOrDefault().Sales);
        }
    }
}
