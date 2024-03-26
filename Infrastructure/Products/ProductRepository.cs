using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace logistics_management_backend.Infrastructure.Products;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DbSet<Product> _objs;
    public ProductRepository(DbContextLM context) : base(context.Products)
    {
        this._objs = context.Products;

    }
}