using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Import
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerEntry> CustomerEntries { get; set; }

        public DataContext() : base("MyTestDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerEntry>()
                .HasRequired<Customer>(c => c.Customer)
                .WithMany(ce => ce.Entries)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
