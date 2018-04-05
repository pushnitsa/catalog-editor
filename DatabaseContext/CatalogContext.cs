using CatalogEditor.Models;
using CatalogEditor.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.DatabaseContext
{
    public class CatalogContext : DbContext
    {

        public CatalogContext(DbContextOptions options)
        :base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new CategoryConfiguration());
        } 
    }
}