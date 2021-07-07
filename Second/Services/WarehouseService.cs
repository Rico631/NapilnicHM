using Second.Context;
using Second.Interfaces;
using Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ShopContext _context;
        //private readonly IProductService _productService;

        public WarehouseService(ShopContext context)
        {
            _context = context;
            //_productService = productService;
        }

        public Stock CreateStock(Stock stock)
        {
            _context.Warehouse.Add(stock);
            _context.SaveChanges();
            return stock;
        }

        public Stock GetStockByProduct(Product product)
        {
            return _context.Warehouse.FirstOrDefault(x => x.Product == product);
        }
        public Stock GetStockByProductID(int productID)
        {
            return _context.Warehouse.FirstOrDefault(x => x.Product.ID == productID);
        }
        public ReserveStock ReserveStock(ReserveStock reserveStock)
        {
            Stock stock = GetStockByProductID(reserveStock.ProductID);
            if (stock == null)
                throw new Exception($"Could not Reserved. Stock not found in Warehouse.\nProductID: {reserveStock.ProductID}");

            var availableQuantity = stock.GetAvailableQuantity();
            if (reserveStock.Quantity > availableQuantity)
                throw new Exception($"Could not Reserved. Reserved quantity gt then available quantity.\nAvailable Quantity: {availableQuantity}, Reserving Quantity: {reserveStock.Quantity}");

            if (reserveStock.Created == DateTime.MinValue)
                reserveStock.Created = DateTime.Now;
            if (reserveStock.Expire == DateTime.MinValue)
                reserveStock.Expire = DateTime.Now.AddDays(3);
            reserveStock.StockID = stock.ID;

            stock.ReserveStocks.Add(reserveStock);

            _context.SaveChanges();

            return reserveStock;
        }

        public void UpdateReservingQuantity(int reserveStockID, int quantity)
        {
            var reserveStock = _context.ReserveStocks.First(x => x.ID == reserveStockID);
            var stock = _context.Warehouse.First(x => x.ID == reserveStock.StockID);
            var availableQuantity = stock.GetAvailableQuantity();
            if (reserveStock.Quantity < quantity)
            {
                if (availableQuantity - (reserveStock.Quantity - quantity) >= 0)
                {
                    reserveStock.Quantity = quantity;
                }
                else
                    throw new Exception($"Could not update reserving quantity. Current available quantity: {availableQuantity}, need: {quantity}");
            }
            else
            {
                reserveStock.Quantity = quantity;
            }
                _context.SaveChanges();
        }

        //public void AddStock(Stock stock)
        //{
        //    Stock checkStock = GetStockByProduct(stock.Product);
        //    if (checkStock != null)
        //        throw new Exception($"Stock already exist. ID: {checkStock.ID}");

        //    Product product = _productService.GetProductByID(stock.ID);
        //    if (product == null)
        //        throw new Exception($"Product not found. ID: {stock.Product.ID}, Name: {stock.Product.Name}");



        //}
    }
}
