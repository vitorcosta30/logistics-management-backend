using logistics_management_backend.Domain.Requests;
using logistics_management_backend.DTO.Products;

namespace logistics_management_backend.DTO.Requests;

public class RequestItemMapper
{
    public static RequestItemDTO toDto(RequestItem item)
    {
        return new RequestItemDTO(ProductMapper.toDto(item.item), item.quantity);
    }

    public static RequestItemDTO[] toDto(RequestItemList items)
    {
        return items.items.ConvertAll<RequestItemDTO>(items => toDto(items)).ToArray();
    }
    
    
}