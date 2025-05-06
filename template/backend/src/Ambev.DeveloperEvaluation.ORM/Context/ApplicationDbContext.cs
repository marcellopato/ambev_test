using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Number).IsRequired();
                e.Property(s => s.CustomerName).IsRequired();
                e.Property(s => s.BranchName).IsRequired();
                e.HasMany(s => s.Items).WithOne(i => i.Sale);
            });

            modelBuilder.Entity<SaleItem>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.ProductName).IsRequired();
            });
        }
    }
}
