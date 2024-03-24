using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;

namespace logistics_management_backend.Infrastructure
{
    public class DbContextLM : DbContext{
        public DbSet<Product> Products {get; set;} 

        
        public DbContextLM(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());



        }
    }
}