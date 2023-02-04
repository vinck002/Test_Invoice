using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.Models;
using Test_Invoice.Services;
using Test_Invoice.Views;

namespace Test_Invoice.Controller
{
    public class CustomerInvoiceDetailController
    {
        private IinvoiceCustomerListView view;
        private IInvoice _invoice;
        private ICustomer customer;
        private BindingSource lstCustomer;
        private BindingSource invoicebindingSource;
        private IEnumerable<Invoice> lstInvoice;

        public CustomerInvoiceDetailController(IinvoiceCustomerListView view, IInvoice invoice, ICustomer customer )
        {
            lstCustomer = new BindingSource();
            invoicebindingSource = new BindingSource();
            this.view = view;
            _invoice = invoice;
            this.customer = customer;
            LoadCustomer();
            this.view.SetiCustomerBindingS(lstCustomer);
            this.view.SetinvoiceBindingS(invoicebindingSource);
            this.view.getInvoiceCustomer += getInvoiceCustomer;
            
        }

        private void getInvoiceCustomer(object sender, EventArgs e)
        {
            lstInvoice = this._invoice.GetAllinvoice(this.view.CustomerID);
            invoicebindingSource.DataSource = lstInvoice;
        }

        private void LoadCustomer()
        {
            lstCustomer.DataSource = this.customer.GetCustomer();
        }
    }
}
