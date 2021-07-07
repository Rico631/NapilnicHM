using Second.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Second.Interfaces
{
    public interface IOrderService
    {
        Order CreateEmptyOrder(Customer customer);

        Order GetOrderByCustomer(Customer customer);
        void UpdateOrder(Order order);
        void UpdateOrderDetailQuantity(OrderDetail orderDetail, int quantity);
    }
}
