using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Models;

namespace Test_Invoice.Services
{
    public interface IInvoice
    {
        Invoice GetInvoice(int id);
        void Saveinvoice(Invoice invoice);
        IEnumerable<Invoice> GetAllinvoice(int CustomerID);

    }
}
