using Second.Context;
using Second.Interfaces;
using Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopContext _context;

        public ProductService(ShopContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
