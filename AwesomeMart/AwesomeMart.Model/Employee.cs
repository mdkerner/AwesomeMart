using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeMart.Data;

namespace AwesomeMart.Model
{
    public class Employee : Person
    {
        public DateTime StartDate { get; set; }
        public Position Position { get; set; }
        public float PayRate { get; set; }
        public PayType PayType { get; set; }
    }
}
