
namespace Test_Invoice.Views
{
    partial class CustomerinvoiceList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.dtgList = new System.Windows.Forms.DataGridView();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItbis1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customers";
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(74, 15);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(268, 21);
            this.cbCustomers.TabIndex = 3;
            // 
            // dtgList
            // 
            this.dtgList.AllowUserToAddRows = false;
            this.dtgList.AllowUserToDeleteRows = false;
            this.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id1,
            this.TotalItbis1,
            this.SubTotal1,
            this.Total1});
            this.dtgList.Location = new System.Drawing.Point(6, 42);
            this.dtgList.Name = "dtgList";
            this.dtgList.Size = new System.Drawing.Size(443, 282);
            this.dtgList.TabIndex = 5;
            // 
            // Id1
            // 
            this.Id1.DataPropertyName = "Id";
            this.Id1.HeaderText = "ID";
            this.Id1.Name = "Id1";
            // 
            // TotalItbis1
            // 
            this.TotalItbis1.DataPropertyName = "SubTotal";
            this.TotalItbis1.HeaderText = "ITBIS ";
            this.TotalItbis1.Name = "TotalItbis1";
            // 
            // SubTotal1
            // 
            this.SubTotal1.DataPropertyName = "SubTotal";
            this.SubTotal1.HeaderText = "Sub-Total";
            this.SubTotal1.Name = "SubTotal1";
            // 
            // Total1
            // 
            this.Total1.DataPropertyName = "Total";
            this.Total1.HeaderText = "Total";
            this.Total1.Name = "Total1";
            // 
            // CustomerinvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 332);
            this.Controls.Add(this.dtgList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCustomers);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(472, 371);
            this.Name = "CustomerinvoiceList";
            this.Text = "CustomerinvoiceList";
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.DataGridView dtgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItbis1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total1;
    }
}