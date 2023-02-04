using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.Models;

namespace Test_Invoice.Views
{
   public interface IinvoiceView
    {

        Invoice Invoice { get; set; }
         int CustomerID { get; set; }
        int Id { get; set; }
         int Qty { get; set; }
         decimal Price { get; set; }
         decimal Itbis { get; set; }
         int InvoiceID { get; set; }
         string Item { get; set; }
        decimal Total { get; set; }
        decimal Subtotal { get; set; }
        decimal SubTotals { get; set; }
        decimal ITBISTotal { get; set; }

        decimal ITbisCargado { get; set; }


         bool  isEdit { get; set; }
        bool isSuccesfull { get; set; }
        string message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler ChangeCustomer;
        event EventHandler EditEvent;
        event EventHandler AddEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ShowinvoiceCustomerList;
        event KeyPressEventHandler Onlydigit;
       

        void SetinvoiceBindingS(BindingSource invoiceList);
        void SetiCustomerBindingS(BindingSource CustomerList);
       void Show();
    }
}
