using logistics_management_backend.Domain.Goods;
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

    public async Task<List<ProductDTO>> getAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<ProductDTO> res =  list.ConvertAll<ProductDTO>(prod => ProductMapper.toDto(prod));
        return res;
    }

    public Task<List<ProductDTO>> getByPosistionAsync(int xPos, int yPos)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDTO> addProduct(ProductDTO dto)
    {
        await _repo.AddAsync(ProductMapper.toDomain(dto));
        await _unitOfwork.CommitAsync();
        return dto;
    }
}