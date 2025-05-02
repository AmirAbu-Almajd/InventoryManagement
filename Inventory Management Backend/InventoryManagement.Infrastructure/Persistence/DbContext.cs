using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<StockRecord> StockRecords { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockRecord>()
                .HasIndex(sr => sr.ProductId)
                .IsUnique(); 
        }
    }
}
