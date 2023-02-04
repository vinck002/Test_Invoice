using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.Models;

namespace Test_Invoice.Views
{
    public interface IinvoiceCustomerListView
    {

         Invoice invoice { get; set; }
         int CustomerID { get; set; }
         

        event EventHandler getInvoiceCustomer;
        event EventHandler SelectInvoice;


        void SetinvoiceBindingS(BindingSource invoiceList);
        void SetiCustomerBindingS(BindingSource CustomerList);
        void Show();

    }
}
