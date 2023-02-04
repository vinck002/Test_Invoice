using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerTypes CustomerTypes { get; set; }
    }
}
