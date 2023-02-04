using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;

namespace Test_Invoice.Services
{
    public interface ICustomer
    {
        List<Customer> GetCustomer();
        List<Customer> GetCustomerById(int id);
        void UpdateCustomer(Customer Ctype);
        void DeleteCustomer(int id);
        List<CustomerTypes> GetCustomerType();

    }
}
