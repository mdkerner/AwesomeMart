using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeMart.Model
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
            Name = "Sales";
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
