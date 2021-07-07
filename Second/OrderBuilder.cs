using Second.Interfaces;
using Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second
{
    public class OrderBuilder
    {
        private readonly Customer _customer;
        //private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IOrderService _orderService;

        private Order Order { get; set; }

        public string PayLink => "http://tiny.cc/xiy9uz";
        public OrderBuilder(Customer customer, IWarehouseService warehouseService, IOrderService orderService)
        {
            _customer = customer;
            //_productService = productService;
            _warehouseService = warehouseService;
            _orderService = orderService;

            Order = _orderService.CreateEmptyOrder(customer);
        }

        public void AddProduct(Product product, int quantity)
        {
            var orderDetail = Order.OrderDetails.FirstOrDefault(x => x.ProductID == product.ID);
            if (orderDetail != null)
                throw new Exception($"Product already added.\nProduct ID: {product.ID}, Name: {product.Name}");

            var reserve = Reservie(product, quantity);
            AddProductToOrder(product, reserve);
        }

        public void UpdateProductQuantity(Product product, int quantity)
        {
            var orderDetail = Order.OrderDetails.First(x => x.ProductID == product.ID);
            if (orderDetail.Quantity == quantity)
                return;
            
            orderDetail.Quantity = quantity;
            
            _warehouseService.UpdateReservingQuantity(orderDetail.ReserveStockID, quantity);
            _orderService.UpdateOrderDetailQuantity(orderDetail, quantity);
        }

        private ReserveStock Reservie(Product product, int quantity)
        {
            Stock stock = _warehouseService.GetStockByProduct(product);
            if (stock == null)
                throw new Exception($"Not found product on Warehouse. Product.Name: {product.Name}.");
            if (stock.GetAvailableQuantity() < quantity)
                throw new Exception($"Not enought products on Warehouse. Current Quantity: {stock.Quantity}. Need Quantity {quantity}");

            var reserve = new ReserveStock(product.ID, _customer.ID, Order.ID, quantity);
            return _warehouseService.ReserveStock(reserve);
        }

        private void AddProductToOrder(Product product, ReserveStock reserve)
        {
            OrderDetail orderDetail = new OrderDetail(product.ID, product, reserve.Quantity, reserve.ID);

            Order.OrderDetails.Add(orderDetail);

            _orderService.UpdateOrder(Order);
        }


    }
}
