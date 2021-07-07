using Second.Context;
using Second.Interfaces;
using Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShopContext _context;

        public CustomerService(ShopContext context)
        {
            _context = context;
        }
        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public Customer CreateCurrentCustomer()
        {
            var customer = new Customer(Environment.UserName);
            return CreateCustomer(customer);
        }
    }
}
