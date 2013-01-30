using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace AwesomeMart.Model
{
    public class AwesomeMartDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
