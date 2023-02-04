using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Data;
using Test_Invoice.Models;

namespace Test_Invoice.Repocitory
{
    public class RCustomerType 
    {
        public List<CustomerTypes> GetCustomerType()
        {
            using (var ctx = new AppDbContext())
            {
                var lst = ctx.CustomerTypes.ToList();
                return lst;
            }
        }
        public List<CustomerTypes> GetCustomerTypeById(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var lst = ctx.CustomerTypes.Where(x => x.Id == id).ToList();
                return lst;
            }
        }
        public void DeleteCustomerType(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var CustomerType = ctx.CustomerTypes.FirstOrDefault(x => x.Id == id);
                ctx.Remove(CustomerType);
                ctx.SaveChanges();
            }
        }
        public void SaveCustomerType(CustomerTypes Ctype)
        {
            using (var ctx = new AppDbContext())
            {

                ctx.CustomerTypes.Update(Ctype);
                ctx.SaveChanges();
            }
        }
    }
}
