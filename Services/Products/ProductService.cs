using logistics_management_backend.Domain.Shared;
using logistics_management_backend.DTO.Products;
using logistics_management_backend.Infrastructure.Products;
using logistics_management_backend.Infrastructure.Requests;

namespace logistics_management_backend.Services.Products;

public class ProductService : IProductService
{
    
    private readonly IUnitOfWork _unitOfwork;
    private readonly IProductRepository _repo;
    
    public ProductService(IUnitOfWork unitOfWork, IProductRepository repository){
        this._unitOfwork = unitOfWork;
        this._repo = repository;
    }

    public Task<List<ProductDTO>> getAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDTO>> getByPosistionAsync(int xPos, int yPos)
    {
        throw new NotImplementedException();
    }
    
    
}