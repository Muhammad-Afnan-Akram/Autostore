using Autostore.Model;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Data
{
    public class AutoStoreContext : DbContext
    {
        public AutoStoreContext(DbContextOptions<AutoStoreContext> options) : base(options)
        {
        }

        public DbSet<BusinessTransactions> BusinessTransactions { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductTransactions> ProductTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTransactions>()
                .HasKey(pt => new { pt.BusinessTransactionsId, pt.ProductId });

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    


}
}
