using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeMart.Model
{
    public class Sale
    {
        public Sale()
        {
            Products = new List<Product>();
        }

        public int ID { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
