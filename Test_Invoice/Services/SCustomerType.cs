using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;
using Test_Invoice.Repocitory;

namespace Test_Invoice.Services
{
    public class SCustomerType : ICustomerType
    {
        RCustomerType Repository = new RCustomerType();


        public void DeleteCustomerType(int id)
        {
            Repository.DeleteCustomerType(id);
        }

        public List<CustomerTypes> GetCustomerType()
        {
           return Repository.GetCustomerType();
        }

        public List<CustomerTypes> GetCustomerTypeById(int id)
        {
            return Repository.GetCustomerTypeById(id);
        }

        public void UpdateCustomerType(CustomerTypes Ctype)
        {
           Repository.SaveCustomerType(Ctype);
        }
    }
}
