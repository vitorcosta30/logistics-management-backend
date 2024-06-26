using logistics_management_backend.Domain.Goods;

namespace logistics_management_backend.DTO.Products;

public class ProductMapper
{
    public static ProductDTO toDto(Product product)
    {
        return new ProductDTO(product.Id, product.description, product.position.posX, product.position.posY);
    }

    public static Product toDomain(ProductDTO dto)
    {
        return new Product(dto.description,dto.xPos,dto.yPos);
    }
}