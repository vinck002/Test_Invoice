using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.DTOs
{
    public class CustomerDTo
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public string Customertype { get; set; }
    }
}
