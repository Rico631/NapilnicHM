using Second.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Second.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer GetCustomerByName(string login);
        Customer CreateCurrentCustomer();
    }
}
