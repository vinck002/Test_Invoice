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
using Test_Invoice.Services;
using Test_Invoice.Views;

namespace Test_Invoice
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }
        ICustomerType customerType = new SCustomerType();
        ICustomer customer = new SCustomer();
        IInvoice invoice = new SInvoice();
        private void button1_Click(object sender, EventArgs e)
        {

            FrmCustomerTypes ct = new FrmCustomerTypes(customerType);
            ct.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCustomers cus = new FrmCustomers(customer);
            cus.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

          
        }
    }
}
