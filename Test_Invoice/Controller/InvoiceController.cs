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


    public class InvoiceController
    {
        private IinvoiceView view;
        private IInvoice invoiceService;
        private ICustomer icustomer;
        private BindingSource InvoiceDetailSource;
        private BindingSource CustomerSource;
        private Invoice Invoice;
        private IEnumerable<Customer> lstCustomer;
        private bool looking = false;
        private decimal Subtotals = 0;
        private decimal ITBISTotal = 0;


        public InvoiceController(IinvoiceView view, IInvoice invoice, ICustomer icustomer)
        {
            this.InvoiceDetailSource = new BindingSource();
            this.CustomerSource = new BindingSource();
            this.view = view;
            this.invoiceService = invoice;
            this.icustomer = icustomer;

            this.view.ITbisCargado = 18;
            //Nos Suscribimos al evento de la vista
            this.view.ShowinvoiceCustomerList += ShowinvoiceCustomerList;
            this.view.SaveEvent += Saveinvoice;
            this.view.AddEvent += Addinvoice;
            this.view.ChangeCustomer += ChangeCustomer;
            this.view.SearchEvent += Searchinvoice;
            this.view.Onlydigit += OnlyDigits;

            LoadCustomer();
            this.view.SetiCustomerBindingS(CustomerSource);
            this.view.SetinvoiceBindingS(InvoiceDetailSource);

            //LoadAllInvoice();

            //this.view.Show();
        }

        private void ShowinvoiceCustomerList(object sender, EventArgs e)
        {
            IinvoiceCustomerListView view = CustomerinvoiceList.Getinstance();
           new CustomerInvoiceDetailController(view, invoiceService, icustomer);
           ((Form)view).Show();

        }

        private void OnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Searchinvoice(object sender, EventArgs e)
        {
            if (this.view.CustomerID != 0)
            {
                Invoice = invoiceService.GetInvoice(this.view.InvoiceID);
                InvoiceDetailSource.DataSource = Invoice.LstInvoicedetail;
                looking = true;
                this.view.CustomerID = Invoice.CustomerId == 0?1: Invoice.CustomerId;
                looking = false;
                this.view.Total = Invoice.Total;
                this.view.SubTotals = Invoice.SubTotal;
                this.view.ITBISTotal = Invoice.TotalItbis;
            }
        }

        private void ChangeCustomer(object sender, EventArgs e)
        {
          
            if (this.view.CustomerID != 0 && !looking)
            {
                
                //Invoice = invoiceService.GetInvoice(this.view.CustomerID);
                Invoice = new Invoice();
                InvoiceDetailSource.DataSource = Invoice.LstInvoicedetail;

            }
        }

        private void Addinvoice(object sender, EventArgs e)
        {
            if (this.Invoice == null)
            {
                this.Invoice = new Invoice();

            }
            if (this.Invoice.LstInvoicedetail == null)
            {
                this.Invoice.LstInvoicedetail = new List<InvoiceDetail>();
                InvoiceDetailSource.DataSource = this.Invoice.LstInvoicedetail;
            }
            this.Invoice.CustomerId = this.view.CustomerID;
            this.Invoice.LstInvoicedetail.Add(
                new InvoiceDetail { 
                    Itbis = this.view.Itbis,
                     Item = this.view.Item,
                     Price = this.view.Price,
                     Qty = this.view.Qty
                     ,Subtotal = this.view.Subtotal
                });

            Subtotals = Invoice.LstInvoicedetail.Sum(x => x.Subtotal);
            ITBISTotal = Invoice.LstInvoicedetail.Sum(x => x.Itbis);

            this.view.ITBISTotal = ITBISTotal;
            this.view.SubTotals = Subtotals;
            this.view.Total = ITBISTotal + Subtotals;
            InvoiceDetailSource.ResetBindings(true);
        }

        private void LoadCustomer()
        {
            lstCustomer = this.icustomer.GetCustomer();
            CustomerSource.DataSource = lstCustomer;
        }

        private void LoadAllInvoice()
        {
            if (this.view.CustomerID != 0)
            {
                Invoice = new Invoice();
                InvoiceDetailSource.DataSource = Invoice.LstInvoicedetail;
                Subtotals = 0;
                ITBISTotal = 0;
                this.view.ITBISTotal = ITBISTotal;
                this.view.SubTotals = Subtotals;
                this.view.Total = 0;
                this.view.Price = 0;
                this.view.Qty = 0;
            }
        }


        private void Saveinvoice(object sender, EventArgs e)
        {
            if (this.Invoice != null)
            {
                 
                Invoice.SubTotal = Subtotals;
                Invoice.TotalItbis = ITBISTotal;
                Invoice.Total = Subtotals + ITBISTotal;
                this.invoiceService.Saveinvoice(this.Invoice);
                LoadAllInvoice();

            }
        }
    }
}
