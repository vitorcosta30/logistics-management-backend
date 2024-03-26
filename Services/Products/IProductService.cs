using logistics_management_backend.DTO.Products;

namespace logistics_management_backend.Services.Products;

public interface IProductService
{
    Task<List<ProductDTO>> getAllAsync();
    
    Task<List<ProductDTO>> getByPosistionAsync(int xPos,int yPos);
    Task<ProductDTO> addProduct(ProductDTO dto);



}