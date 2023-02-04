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
    public class RInvoice : IInvoice
    {
        public IEnumerable<Invoice> GetAllinvoice(int CustomerID)
        {
            using (var ctx = new AppDbContext())
            {
                var result = ctx.invoice.Where(x => x.CustomerId == CustomerID).Include(x => x.LstInvoicedetail).ToList();
               
                return result;
            }
        }

        public Invoice GetInvoice(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var result = ctx.invoice.Where(x => x.Id == id).Include(x => x.LstInvoicedetail).FirstOrDefault();
                if (result == null)
                {
                    result = new Invoice();
                }
                return result;
            }
        }

        public void Saveinvoice(Invoice entity)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.invoice.Update(entity);
                ctx.SaveChanges();
            }
        }
    }
}
