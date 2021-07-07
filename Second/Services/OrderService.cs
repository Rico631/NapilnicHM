using Second.Context;
using Second.Interfaces;
using Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShopContext _context;

        public OrderService(ShopContext context)
        {
            _context = context;
        }

        public Order CreateEmptyOrder(Customer customer)
        {
            var order = new Order(customer.ID, DateTime.Now);
            
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }

        public void UpdateOrderDetailQuantity(OrderDetail orderDetail, int quantity)
        {
            _context.OrderDetails.First(x => x.ID == orderDetail.ID).Quantity = quantity;
            _context.SaveChanges();
        }
    }
}
