using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeMart.Model;
using AwesomeMart.Enumerations;
using System.Data.Entity.Validation;

namespace AwesomeMart.Test.Model
{
    [TestClass]
    public class Employee_Test
    {
        [TestMethod]
        public void can_add_new_employee()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Assert.IsFalse((from e in context.Employees
                            select e).Count() == 1);

            context.Employees.Add(new Employee());
            context.SaveChanges();

            Assert.AreEqual(1, (from e in context.Employees
                                select e).Count());
        }

        [TestMethod]
        public void can_retrieve_employee()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            context.Employees.Add(new Employee());
            context.SaveChanges();

            Employee retrievedEmployee = (from e in context.Employees
                                          select e).FirstOrDefault();

            Assert.IsNotNull(retrievedEmployee);
        }

        [TestMethod]
        public void can_edit_employee()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            context.Employees.Add(new Employee { Name = "Dave" });
            context.SaveChanges();

            Assert.AreEqual("Dave", (from e in context.Employees
                                     select e.Name).FirstOrDefault());

            Employee editEmployee = (from e in context.Employees
                                     select e).FirstOrDefault();

            editEmployee.Name = "Steve";
            context.SaveChanges();

            Assert.AreEqual("Steve", (from e in context.Employees
                                      select e.Name).FirstOrDefault());
        }

        [TestMethod]
        public void can_seed_database_with_employee()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            Assert.AreEqual(1, (from e in context.Employees
                                select e).Count());
        }

        [TestMethod]
        public void can_delete_employee()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;


            Assert.AreEqual(1, (from e in context.Employees
                                where e.Name.Equals("John Davis")
                                select e).Count());

            context.Employees.Remove((from e in context.Employees
                                      where e.Name.Equals("John Davis")
                                      select e).FirstOrDefault());

            context.SaveChanges();

            Assert.AreEqual(0, (from e in context.Employees
                                where e.Name.Equals("John Davis")
                                select e).Count());
        }

        [TestMethod]
        public void default_value_for_start_date_is_null()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            context.Employees.Add(new Employee());
            context.SaveChanges();

            Assert.IsNull((from e in context.Employees
                           select e.StartDate).FirstOrDefault());
        }

        [TestMethod]
        public void default_value_for_pay_rate_is_zero()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            context.Employees.Add(new Employee());
            context.SaveChanges();

            Assert.AreEqual(0, (from e in context.Employees
                                select e.PayRate).FirstOrDefault());

        }

        [TestMethod]
        public void default_value_for_position_is_null()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            context.Employees.Add(new Employee());
            context.SaveChanges();

            Assert.IsNull((from e in context.Employees
                           select e).FirstOrDefault().Position);
        }

        [TestMethod]
        public void default_value_for_pay_type_is_hourly()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            context.Employees.Add(new Employee());
            context.SaveChanges();

            Assert.AreEqual(PayType.Hourly, (from e in context.Employees
                                             select e).FirstOrDefault().PayType);
        }

        [TestMethod]
        public void pay_type_is_able_to_be_changed()
        { 
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            context.Employees.Add(new Employee
                {
                    PayType = PayType.Hourly
                });
            context.SaveChanges();

            Assert.AreEqual(PayType.Hourly, (from e in context.Employees
                                             select e).FirstOrDefault().PayType);

            Employee editEmployee = context.Employees.FirstOrDefault();
            editEmployee.PayType = PayType.Monthly;

            context.SaveChanges();

            Assert.AreEqual(PayType.Monthly, (from e in context.Employees
                                             select e).FirstOrDefault().PayType);

        }

        [TestMethod]
        public void linq_shorthand_is_equivalent_to_regular_syntax()
        {
            AwesomeMartDb context = DbInitializer.SeededAwesomeMartDbContext;

            Employee shorthand = context.Employees.FirstOrDefault(e => e.Name.Equals("John Davis"));

            Employee regular = (from e in context.Employees
                                where e.Name.Equals("John Davis")
                                select e).FirstOrDefault();

            Assert.AreEqual(shorthand, regular);
        }

        [TestMethod]
        public void id_field_is_updated_locally_when_the_context_is_saved()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee();

            Assert.AreEqual(0, newEmployee.ID);

            context.Employees.Add(newEmployee);

            Assert.AreEqual(0, newEmployee.ID);

            context.SaveChanges();

            Assert.AreNotEqual(0, newEmployee.ID);
        }

        [TestMethod]
        public void pay_rate_cant_be_negative()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = -1
            };

            context.Employees.Add(newEmployee);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void pay_rate_can_be_0()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = 0
            };

            context.Employees.Add(newEmployee);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void pay_rate_cant_be_more_than_5000000000()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = 5000000001
            };

            context.Employees.Add(newEmployee);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void pay_rate_can_be_5000000000()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = 5000000000
            };

            context.Employees.Add(newEmployee);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void can_get_validation_message_from_annotation()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = -1
            };

            context.Employees.Add(newEmployee);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                Assert.AreEqual(context.GetValidationErrors().FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage, "That's a ridiculous amount to be paid... Let's be real, here.");
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void can_check_for_validation_before_saving()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;


            Assert.AreEqual(0, context.GetValidationErrors().Count());

            Employee newEmployee = new Employee
            {
                PayRate = -1
            };

            context.Employees.Add(newEmployee);

            Assert.AreNotEqual(0, context.GetValidationErrors().Count());
        }

        [TestMethod]
        public void can_get_invalid_entity()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;

            Employee newEmployee = new Employee
            {
                PayRate = -1
            };

            context.Employees.Add(newEmployee);

            Assert.AreSame(newEmployee, context.GetValidationErrors().FirstOrDefault().Entry.Entity);
        }

        [TestMethod]
        public void enums_save_even_Thought_They_dont_Show_up()
        {
            AwesomeMartDb context = DbInitializer.EmptyAwesomeMartDbContext;
            Employee emp = new Employee();
            context.Employees.Add(emp);
            context.SaveChanges();

            Assert.IsNull((from e in context.Employees
                           select e).FirstOrDefault().Position);

            emp.Position = Position.Cashier;
            context.SaveChanges();

            Assert.AreEqual(Position.Cashier, context.Employees.FirstOrDefault().Position);


            emp.Position = Position.Manager;
            context.SaveChanges();

            Assert.AreEqual(Position.Manager, context.Employees.FirstOrDefault().Position);

        }
    }
}
