using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Infrastructure.Products;
using logistics_management_backend.Infrastructure.Requests;
using Microsoft.EntityFrameworkCore;

namespace logistics_management_backend.Infrastructure
{
    public class DbContextLM : DbContext{
        public DbSet<Product> Products {get; set;} 
        public DbSet<Request> Requests {get; set;} 

        
        public DbContextLM(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPositionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestHistoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestHistoryItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestListEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestListItemEntityTypeConfiguration());



        }
    }
}