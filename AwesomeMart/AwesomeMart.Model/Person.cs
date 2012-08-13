using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeMart.Model
{
    abstract public class Person
    {
        public virtual string Name { get; set; }
        public virtual string Race { get; set; }
        public virtual string Address { get; set; }
        public virtual int CreateDate { get; set; }
        public virtual int ID { get; set; }
        public virtual int Age { get; set; }
        public virtual int Phone { get; set; }
        
    }
}
