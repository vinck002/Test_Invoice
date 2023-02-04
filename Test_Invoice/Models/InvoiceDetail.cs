using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Itbis { get; set; }
        public decimal  Subtotal { get; set; }
        public int InvoiceID { get; set; }
        public string Item { get; set; }
        public Invoice Invoice { get; set; }



    }
}
