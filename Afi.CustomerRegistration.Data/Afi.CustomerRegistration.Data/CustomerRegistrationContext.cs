using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Afi.CustomerRegistration.Data
{
    public class CustomerRegistrationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\CustomerRegistration.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
