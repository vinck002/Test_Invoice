using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;
using Test_Invoice.Repocitory;

namespace Test_Invoice.Services
{
    public class SCustomer: ICustomer
    {
        RCustomer Repository = new RCustomer();


        public void DeleteCustomer(int id)
        {
            Repository.DeleteCustomer(id);
        }

        public List<Customer> GetCustomer()
        {
            return Repository.GetCustomer();
        }

        public List<Customer> GetCustomerById(int id)
        {
            return Repository.GetCustomerById(id);
        }


        public void UpdateCustomer(Customer Ctype)
        {
            Repository.SaveCustomer(Ctype);
        }

        public List<CustomerTypes> GetCustomerType()
        {
            return Repository.GetCustomerType();
        }
    }
}
