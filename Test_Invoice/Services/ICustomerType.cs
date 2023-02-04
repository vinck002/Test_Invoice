using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;

namespace Test_Invoice.Services
{
    public interface ICustomerType
    {
        List<CustomerTypes> GetCustomerType();
        List<CustomerTypes> GetCustomerTypeById(int id);
        void UpdateCustomerType(CustomerTypes Ctype);
        void DeleteCustomerType(int id);

    }
}
