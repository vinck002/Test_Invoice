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
  
    //public delegate void MyEventHan(object sender, EventArgs e);
    public partial class InvoiceView : Form , IinvoiceView
    {

        public InvoiceView()
        {
            InitializeComponent();
            EventAsociated();
        }

        private void EventAsociated()
        {
            commonTExtboxEvent();

            //btnEvents
            btnCustomerInvoice.Click += delegate { ShowinvoiceCustomerList?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += (o,e) => CancelEvent?.Invoke(this,EventArgs.Empty);
            BtnAdd.Click += (o, e) => AddEvent?.Invoke(this, EventArgs.Empty);
            btnSubmit.Click += (o, e) => SaveEvent?.Invoke(this, EventArgs.Empty);
            btnSearchInvoice.Click += (o, e) => SearchEvent?.Invoke(this, EventArgs.Empty);
            cbCustomers.SelectedIndexChanged += (o, e) => ChangeCustomer?.Invoke(this, EventArgs.Empty);
        }

        private void commonTExtboxEvent()
        {
            txtPrice.KeyPress += (o, e) => Onlydigit?.Invoke(this, e);
            txtqty.KeyPress += (o, e) => Onlydigit?.Invoke(this, e);
            txtITBIS.KeyPress += (o, e) => Onlydigit?.Invoke(this, e);
            txtInvoiceNumber.KeyPress += (o, e) => Onlydigit?.Invoke(this, e);
        }


        public decimal ITbisCargado { get; set; }
        public int Id { get; set; }
        public string Item { get => txtItem.Text; set => txtItem.Text = value; }
        public int Qty { get => String.IsNullOrEmpty(txtqty.Text) ? 1 : Convert.ToInt32(txtqty.Text); set => txtqty.Text = value.ToString(); }
        public decimal Price { get => String.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text); set => txtPrice.Text = value.ToString(); }
        public decimal Itbis { get => String.IsNullOrEmpty(txtITBIS.Text) ? 0 : Convert.ToDecimal(txtITBIS.Text); set => txtITBIS.Text = value.ToString(); }
        public decimal Subtotal { get { return String.IsNullOrEmpty(txtDetailSubTotal.Text) ? 0 : Convert.ToDecimal(txtDetailSubTotal.Text.Replace("$","")); } set { txtDetailSubTotal.Text = value.ToString(); } }
        public decimal Total { get { return Convert.ToDecimal(txtTotal.Text); } set { txtTotal.Text = value.ToString(); } }
        public decimal SubTotals { get { return Convert.ToDecimal(txtSubTotal.Text); } set { txtSubTotal.Text = value.ToString(); } }
        public decimal ITBISTotal { get { return Convert.ToDecimal(txtTotalITBIS.Text); } set { txtTotalITBIS.Text = value.ToString(); } }
        public Invoice Invoice { get; set; }
       
        public bool isEdit { get ; set; }
        public bool isSuccesfull { get; set; }
        public string message { get; set; }

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
        public int InvoiceID
        {
            get
            {
                if (!string.IsNullOrEmpty(txtInvoiceNumber.Text))
                {
                    return Convert.ToInt32(txtInvoiceNumber.Text);

                }
                else
                {
                    return 0;
                };
            }
            set
            {
                txtInvoiceNumber.Text =  value.ToString();
            }
        }
        

        public event EventHandler SearchEvent;
        public event EventHandler ChangeCustomer;
        public event EventHandler EditEvent;
        public event EventHandler AddEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ShowinvoiceCustomerList;
        public event KeyPressEventHandler Onlydigit;

        public void SetinvoiceBindingS(BindingSource invoiceList)
        {
            dtgList.AutoGenerateColumns = false;
            dtgList.DataSource = invoiceList;
        }
        public void SetiCustomerBindingS(BindingSource CustomerList)
        {
            cbCustomers.DisplayMember = "CustName";
            cbCustomers.ValueMember = "Id";
            cbCustomers.DataSource = CustomerList.DataSource;
        }


        private static InvoiceView instance;
        public static InvoiceView Getinstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new InvoiceView();
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

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtqty.Text))
            {
                txtqty.Text = "1";
            }

            decimal qtyXPrice = (String.IsNullOrEmpty(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text))
                 * (String.IsNullOrEmpty(txtqty.Text) ? 0 : Convert.ToDecimal(txtqty.Text));

            decimal ItbisApplied = qtyXPrice / (1 + (ITbisCargado/100));
            txtDetailSubTotal.Text = ItbisApplied.ToString("C2");

            txtITBIS.Text = (Subtotal * (ITbisCargado / 100)).ToString();

        }
    }
}
