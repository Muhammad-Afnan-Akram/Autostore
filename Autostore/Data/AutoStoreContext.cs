using Autostore.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Data
{
    public class AutoStoreContext : IdentityDbContext
    {
        public AutoStoreContext(DbContextOptions<AutoStoreContext> options) : base(options)
        {
        }

        public DbSet<CustomerTransactions> CustomerTransactions { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductTransaction> ProductTransaction { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockHistory> StockHistory { get; set; }

        


    }
}
