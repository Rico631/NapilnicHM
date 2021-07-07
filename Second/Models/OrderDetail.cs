using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {

        }
        public OrderDetail(int productID, Product product, int quantity, int reserveStockID)
        {
            ProductID = productID;
            Product = product;
            Quantity = quantity;
            ReserveStockID = reserveStockID;
        }

        public OrderDetail(int iD, int productID, Product product, int quantity, int reserveStockID)
        {
            ID = iD;
            ProductID = productID;
            Product = product;
            Quantity = quantity;
            ReserveStockID = reserveStockID;
        }

        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ReserveStockID { get; set; }
    }
}
