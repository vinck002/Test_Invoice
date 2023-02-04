using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.Models;

namespace Test_Invoice.Views
{
    public partial class CustomerinvoiceList : Form, IinvoiceCustomerListView
    {
        public CustomerinvoiceList()
        {
            InitializeComponent();
            EventAsociated();
        }

        private void EventAsociated()
        {
            cbCustomers.SelectedIndexChanged += (o, e) =>
            {
                if (cbCustomers.DataSource != null)
                {
                    getInvoiceCustomer?.Invoke(this, e);
                }
            };
            this.Load += (o, e) =>
            {
                if (cbCustomers.DataSource != null)
                {
                    getInvoiceCustomer?.Invoke(this, e);
                }
            };



        }

        public Invoice invoice { get; set; }
        public int CustomerID
        {
            get
            {
                if (cbCustomers.DataSource != null)
                {
                    return Convert.ToInt32(cbCustomers.SelectedValue);
                }
                else { return 0; }
            }
            set
            {
                if (cbCustomers.DataSource != null)
                {
                    cbCustomers.SelectedValue = value;
                }

            }

        }

        public event EventHandler getInvoiceCustomer;
        public event EventHandler SelectInvoice;

        public void SetiCustomerBindingS(BindingSource CustomerList)
        {
         
            cbCustomers.DataSource = CustomerList.DataSource;
            cbCustomers.DisplayMember = "CustName";
            cbCustomers.ValueMember = "Id";
        }

        public void SetinvoiceBindingS(BindingSource invoiceList)
        {
            dtgList.AutoGenerateColumns = false;
            dtgList.DataSource = invoiceList;
        }
        
        
        private static CustomerinvoiceList instance;
        
        public static CustomerinvoiceList Getinstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerinvoiceList();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                    instance.BringToFront();
                }
            }
            return instance;


        }
    }
}
