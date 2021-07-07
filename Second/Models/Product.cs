using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
