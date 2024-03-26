using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Infrastructure.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetAllAsyncWithPositions();
    
    Task<Product> GetByIdAsyncWithPositions(long id);


}