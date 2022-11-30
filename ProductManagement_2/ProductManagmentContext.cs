using Microsoft.EntityFrameworkCore;
using ProductManagement_2.Entities;

namespace ProductManagement_2
{
    public class ProductManagmentContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ProductManagmentContext()
        {

        }

        public ProductManagmentContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
