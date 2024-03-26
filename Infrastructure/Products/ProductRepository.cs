using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Shared;
using logistics_management_backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace logistics_management_backend.Infrastructure.Products;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DbSet<Product> _objs;
    public ProductRepository(DbContextLM context) : base(context.Products)
    {
        this._objs = context.Products;

    }

    public async Task<List<Product>> GetAllAsyncWithPositions()
    {
        return await this._objs.Include(prod => prod.position).ToListAsync();

    }

    public async Task<Product> GetByIdAsyncWithPositions(long id)
    {
        return await this._objs.Include(prod => prod.position)
            .Where(x => id.Equals(x.Id)).FirstOrDefaultAsync();
    }


    public override IIncludableQueryable<Product, ProductPosition> getAllObjects()
    {
        return this._objs.Include(prod => prod.position);
    }
}