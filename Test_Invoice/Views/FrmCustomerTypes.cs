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

namespace Test_Invoice
{
    public partial class FrmCustomerTypes : Form
    {
        private readonly ICustomerType IcustomerType;
        private List<CustomerTypes> lstCutomerT;
        private CustomerTypes customerType;
        public FrmCustomerTypes(ICustomerType _CustomerType)
        {
            InitializeComponent();
            IcustomerType = _CustomerType;
            LoadData();
        }
      
        private void LoadData()
        {
            lstCutomerT = IcustomerType.GetCustomerType();
            DtgList.DataSource = lstCutomerT;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (customerType == null)
            {
                customerType = new CustomerTypes();
            }
            if (lstCutomerT.Any(x => x.Description.ToLower() != txtDescription.Text.ToLower()))
            {
                customerType.Description = txtDescription.Text;
                 IcustomerType.UpdateCustomerType(customerType);
                customerType =null ;
                LoadData();
                txtDescription.Text = string.Empty;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            IcustomerType.DeleteCustomerType(Convert.ToInt32(DtgList.CurrentRow.Cells["Id"].Value));
            CustomerTypes ctype = lstCutomerT.FirstOrDefault(x => x.Id == Convert.ToInt32(DtgList.CurrentRow.Cells["Id"].Value));
            LoadData();
        }
    }
}
