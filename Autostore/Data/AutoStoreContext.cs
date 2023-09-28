﻿using Autostore.Model;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Data
{
    public class AutoStoreContext : DbContext
    {
        public AutoStoreContext(DbContextOptions<AutoStoreContext> options) : base(options)
        {
        }

        public DbSet<CustomerTransaction> CustomerTransaction { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductTransaction> ProductTransaction { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockHistory> StockHistory { get; set; }

        


    }
}
