using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Afi.CustomerRegistration.Data
{
    public class CustomerRegistrationContext : DbContext
    {
        public CustomerRegistrationContext(DbContextOptions<CustomerRegistrationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=CustomerRegistration.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property<int>(nameof(Customer.Id)).ValueGeneratedOnAdd();
        }
    }
}
