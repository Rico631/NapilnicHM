using System;

namespace Second.Models
{
    public class ReserveStock
    {
        public ReserveStock()
        {

        }
        public ReserveStock(int productID, int customerID, int orderID, int quantity)
        {
            //TODO: Add validation
            CustomerID = customerID;
            OrderID = orderID;
            Quantity = quantity;
            ProductID = productID;
        }
        public int ID { get; set; }
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }
        public bool Expired { get => DateTime.Now > Expire; }
    }
}
