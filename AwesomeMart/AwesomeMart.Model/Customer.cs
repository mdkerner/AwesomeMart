using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeMart.Model
{
    public class Customer : Person
    {
        public ICollection<Sale> Sales { get; set; }
    }
}
