using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.Models
{
    public class CustomerTypes
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
