using logistics_management_backend.Domain.Goods;

namespace logistics_management_backend.DTO.Products;

public class ProductPositionMapper
{
    public static ProductPositionDTO toDto(ProductPosition position)
    {
        return new ProductPositionDTO(position.posX, position.posY);
    }

    public static ProductPositionDTO[] toDto(ProductPosition[] positions)
    {
        ProductPositionDTO[] res = new ProductPositionDTO [positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            res[i] = toDto(positions[i]);

        }

        return res;
    }
}