using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;
using Test_Invoice.Repocitory;

namespace Test_Invoice.Services
{
    public class SInvoice : IInvoice
    {
        RInvoice invoice = new RInvoice();

        public IEnumerable<Invoice> GetAllinvoice(int CustomerID)
        {
            return invoice.GetAllinvoice(CustomerID);
        }

        public Invoice GetInvoice(int id)
        {
            return invoice.GetInvoice(id);
        }

        public void Saveinvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
