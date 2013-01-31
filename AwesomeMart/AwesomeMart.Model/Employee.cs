using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AwesomeMart.Enumerations;

namespace AwesomeMart.Model
{
    public class Employee : Person
    {
        //DateTimes have to be nullable, or the database will throw a "An overflow occurred while converting to datetime." exception
        //This is because .NET's min datetime is 1/1/0001 and the DB's min datetime is 1/1/1753. Oh, Database. You so silly.
        //Besides, we want to the default value to be null, and not 1/1/0001.
        public DateTime? StartDate { get; set; }

        //Shows you can have a null enumeration
        public Position? Position { get; set; }

        //Example of validation
        [Range(0, 5000000000, ErrorMessage="That's a ridiculous amount to be paid... Let's be real, here.")]
        public double PayRate { get; set; }

        public Department Department { get; set; }

        public PayType PayType { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

    }
}
