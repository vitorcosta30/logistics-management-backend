using logistics_management_backend.Domain.Requests;
using logistics_management_backend.DTO.Products;

namespace logistics_management_backend.DTO.Requests;

public class RequestItemDTO
{
    public ProductDTO product;

    public int quantity;

    public RequestItemDTO(ProductDTO product, int quantity)
    {
        this.product = product;
        this.quantity = quantity;
    }
}