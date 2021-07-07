using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Order(int customerID, DateTime created)
        {
            OrderDetails = new HashSet<OrderDetail>();
            CustomerID = customerID;
            Created = created;
        }

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Created { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
