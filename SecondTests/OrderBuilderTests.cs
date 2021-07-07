using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Second;
using Second.Context;
using Second.Interfaces;
using Second.Models;
using Second.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second.Tests
{
    [TestFixture()]
    public class OrderBuilderTests
    {
        ShopContext Context;
        IOrderService OrderService;
        IWarehouseService WarehouseService;
        OrderBuilder OrderBuilder1;
        OrderBuilder OrderBuilder2;

        [OneTimeSetUp]
        public void Setup()
        {

            CreateContext();
            CreateServices();
            CreateOrderBuilder1();
            CreateOrderBuilder2();
        }
        [Test()]
        [Order(1)]
        public void OrderBuilder1_Created()
        {
            var customer = Context.Customers.First();
            var order = Context.Orders.First();

            Assert.AreEqual(customer.ID, order.CustomerID);
            Assert.AreEqual(0, order.OrderDetails.Count);

        }

        [Test()]
        [Order(2)]
        public void OrderBuilder1_Add_Product1()
        {
            int count = 1;
            var product = Context.Products.First();

            OrderBuilder1.AddProduct(product, count);

            var order = Context.Orders.First();
            Assert.AreEqual(count, order.OrderDetails.Count);
            Assert.AreEqual(product.ID, order.OrderDetails.First().ProductID);
            Assert.AreEqual(count, order.OrderDetails.First().Quantity);

            var reserve = Context.ReserveStocks.First();
            Assert.AreEqual(product.ID, reserve.ProductID);
            Assert.AreEqual(count, reserve.Quantity);

            var stock = Context.Warehouse.First(x => x.Product == product);
            Assert.AreEqual(0, stock.GetAvailableQuantity());
        }

        [Test()]
        [Order(3)]
        public void OrderBuilder1_Fail_Re_Add_Product1()
        {
            var product = Context.Products.First();

            Assert.Throws<Exception>(() => OrderBuilder1.AddProduct(product, 1));
        }
        [Test()]
        [Order(4)]
        public void OrderBuilder1_Add_Product2_And_Check_AvailableQauantity()
        {
            int count = 1;
            var product = Context.Products.Last();
            OrderBuilder1.AddProduct(product, count);

            var order = Context.Orders.First();
            Assert.AreEqual(2, order.OrderDetails.Count);
            Assert.AreEqual(product.ID, order.OrderDetails.Last().ProductID);
            Assert.AreEqual(count, order.OrderDetails.Last().Quantity);

            var reserve = Context.ReserveStocks.Last();
            Assert.AreEqual(product.ID, reserve.ProductID);
            Assert.AreEqual(count, reserve.Quantity);

            var stock = Context.Warehouse.First(x => x.Product == product);
            Assert.AreEqual(2, stock.GetAvailableQuantity());
        }
        [Test()]
        [Order(5)]
        public void OrderBuilder2_Fail_Add_Product1()
        {
            int count = 1;
            var product = Context.Products.First();
            Assert.Throws<Exception>(() => OrderBuilder2.AddProduct(product, count));

            var order = Context.Orders.Last();
            Assert.AreEqual(0, order.OrderDetails.Count);
            var reserve = Context.ReserveStocks.FirstOrDefault(x => x.CustomerID == Context.Customers.Last().ID);
            Assert.IsNull(reserve);
        }
        [Test()]
        [Order(6)]
        public void OrderBuilder2_Add_Product2_And_Check_AvailableQauantity()
        {
            var customer = Context.Customers.Last();
            int count = 2;
            var product = Context.Products.Last();
            OrderBuilder2.AddProduct(product, count);

            var order = Context.Orders.FirstOrDefault(x => x.CustomerID == customer.ID);
            Assert.AreEqual(1, order.OrderDetails.Count);
            Assert.AreEqual(product.ID, order.OrderDetails.Last().ProductID);
            Assert.AreEqual(count, order.OrderDetails.Last().Quantity);

            var reserve = Context.ReserveStocks.Last();
            Assert.AreEqual(product.ID, reserve.ProductID);
            Assert.AreEqual(count, reserve.Quantity);

            var stock = Context.Warehouse.First(x => x.Product == product);
            Assert.AreEqual(0, stock.GetAvailableQuantity());
        }

        [Test()]
        [Order(7)]
        public void Check_ProductReserve()
        {
            var product1 = Context.Products.First();
            var product2 = Context.Products.Last();

            var stock1 = Context.Warehouse.First(x => x.Product == product1);
            var stock2 = Context.Warehouse.First(x => x.Product == product2);

            Assert.AreEqual(1, stock1.Quantity);
            Assert.AreEqual(0, stock1.GetAvailableQuantity());
            Assert.AreEqual(1, stock1.ReserveStocks.Count());

            Assert.AreEqual(3, stock2.Quantity);
            Assert.AreEqual(0, stock2.GetAvailableQuantity());
            Assert.AreEqual(2, stock2.ReserveStocks.Count());
        }

        private void CreateContext()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;

            Context = new ShopContext(options);
            FillContext();
        }
        private void FillContext()
        {
            List<Product> products = new List<Product>
            {
                new Product("Prod1", 123),
                new Product("Prod2",3.2m),
                new Product("Prod3", 43.2323m)
            };
            Context.Products.AddRange(products);

            List<Customer> customers = new List<Customer>()
            {
                new Customer("Customer1"),
                new Customer("Customer2")
            };
            Context.Customers.AddRange(customers);
            //Context.SaveChanges();
            Context.Warehouse.AddRange(products.Select((x, i) => new Stock(x, i + 1)));
            Context.SaveChanges();
        }
        private void CreateServices()
        {
            OrderService = new OrderService(Context);
            WarehouseService = new WarehouseService(Context);
        }
        private void CreateOrderBuilder1()
        {
            var customer = Context.Customers.First();
            OrderBuilder1 = new OrderBuilder(customer, WarehouseService, OrderService);
        }
        private void CreateOrderBuilder2()
        {
            var customer = Context.Customers.Last();
            OrderBuilder2 = new OrderBuilder(customer, WarehouseService, OrderService);
        }
    }
}
