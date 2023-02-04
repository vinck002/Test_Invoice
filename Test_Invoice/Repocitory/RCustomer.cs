using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Data;
using Test_Invoice.Models;
using Test_Invoice.Services;

namespace Test_Invoice.Repocitory
{
    public class RCustomer: ICustomer
    {

        public List<Customer> GetCustomer()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Customers.Include(x => x.CustomerTypes).ToList();
            }
        }
        public List<Customer> GetCustomerById(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var lst = ctx.Customers.Where(x => x.Id == id).Include(x => x.CustomerTypes).ToList();
                return lst;
            }
        }
        public void DeleteCustomer(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var CustomerType = ctx.Customers.FirstOrDefault(x => x.Id == id);
                ctx.Remove(CustomerType);
                ctx.SaveChanges();
            }
        }
        public void SaveCustomer(Customer Ctype)
        {
            using (var ctx = new AppDbContext())
            {

                ctx.Customers.Update(Ctype);
                ctx.SaveChanges();
            }
        }
        public List<CustomerTypes> GetCustomerType()
        {
            using (var ctx = new AppDbContext())
            {
                var lst = ctx.CustomerTypes.ToList();
                return lst;
            }
        }

        public void UpdateCustomer(Customer Ctype)
        {
            throw new NotImplementedException();
        }
    }
}
