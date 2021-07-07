using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public Customer(string name)
        {
            Name = name;
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
