using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.Controller;
using Test_Invoice.Models;
using Test_Invoice.Services;
using Test_Invoice.Repocitory;
using Test_Invoice.Views;

namespace Test_Invoice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IinvoiceView invoiceview = new InvoiceView();
            IInvoice InvoiceService = new RInvoice();
            ICustomer CustomerSerice = new RCustomer();
            new InvoiceController(invoiceview, InvoiceService, CustomerSerice);
            Application.Run((Form)invoiceview);
        }
    }
}
