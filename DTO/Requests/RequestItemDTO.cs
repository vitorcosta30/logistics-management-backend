using logistics_management_backend.Domain.Requests;
using logistics_management_backend.DTO.Products;

namespace logistics_management_backend.DTO.Requests;

public class RequestItemDTO
{
    public long id; 

    public ProductDTO product;

    public int quantity;

    public bool isCollected;

    public RequestItemDTO(long id, ProductDTO product, int quantity,bool isCollected)
    {
        this.id = id;
        this.product = product;
        this.quantity = quantity;
        this.isCollected = isCollected;
    }
}