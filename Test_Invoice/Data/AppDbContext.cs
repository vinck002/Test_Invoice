using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice.Config;
using Test_Invoice.Models;

namespace Test_Invoice.Data
{
    public class AppDbContext: DbContext
    {
        string StringConnection;
        public AppDbContext()
        {
            SqlCon ConectionStr = new SqlCon();
            StringConnection = ConectionStr.ConnectionSt;
        }


        public DbSet<Invoice> invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTypes> CustomerTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasOne<CustomerTypes>(sc => sc.CustomerTypes)
            .WithMany(s => s.Customers)
            .HasForeignKey(sc => sc.CustomerTypeId);

            modelBuilder.Entity<InvoiceDetail>()
            .HasOne<Invoice>(sc => sc.Invoice)
            .WithMany(s => s.LstInvoicedetail)
            .HasForeignKey(sc => sc.InvoiceID);
        }

    }
}
