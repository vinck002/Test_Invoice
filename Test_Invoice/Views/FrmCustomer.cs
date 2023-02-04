using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Invoice.DTOs;
using Test_Invoice.Models;
using Test_Invoice.Services;

namespace Test_Invoice.Views
{
    public partial class FrmCustomers : Form
    {
        private readonly ICustomer customer;
        List<Customer> lstCustomer;
        List<CustomerTypes> lstCustomertypes;
        List<CustomerDTo> lstCustomerDto;
        Customer _Customer;
        public FrmCustomers(ICustomer Customer)
        {
            customer = Customer;
            InitializeComponent();
            loadGridData();
            loadCustomertypes();
        }
        private void loadCustomertypes()
        {
            lstCustomertypes = customer.GetCustomerType();
            cbCustType.DisplayMember = "Description";
            cbCustType.ValueMember = "Id";
            cbCustType.DataSource = lstCustomertypes;
        }

        private void loadGridData()
        {
            lstCustomer = customer.GetCustomer();
            lstCustomerDto = lstCustomer.Select(x => new CustomerDTo
            {
                Adress = x.Adress,
                CustName = x.CustName,
                Customertype = x.CustomerTypes.Description,
                Id = x.Id
            ,
                Status = x.Status
            }).ToList();
            DtgList.DataSource = lstCustomerDto;
        }

        void cleanfields()
        {
            txtDescription.Text = "";
            txtAddresse.Text = "";
            chStatus.Checked = true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Customer == null)
            {
                _Customer = new Customer();
            }
            _Customer.Adress = txtAddresse.Text;
            _Customer.CustName = txtDescription.Text;
            _Customer.Status = chStatus.Checked;
            _Customer.CustomerTypeId = Convert.ToInt32(cbCustType.SelectedValue);

            customer.UpdateCustomer(_Customer);
            cleanfields();
            loadGridData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _Customer = null;
            cleanfields();
        }
    }
}
