using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeMart.Model
{
    abstract public class Person
    {
        public virtual string Name { get; set; }
        public virtual int ID { get; set; }
    }
}
