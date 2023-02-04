using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.Models
{
    public interface IInvoiceRepository
    {
        void Add(Invoice customer);
        void Edit(Invoice customer);
        void Delete(int customer);
        IEnumerable<Invoice> GetAll();
        IEnumerable<Invoice> GetByValue(string value);
    }
}
