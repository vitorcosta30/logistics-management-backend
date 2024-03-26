using logistics_management_backend.Domain.Requests;
using logistics_management_backend.DTO.Products;

namespace  logistics_management_backend.DTO.Requests;

public class RequestDTO
{
    public long Id; 
    
    public RequestItemDTO[] requestItems;

    public string currentStatus;

    public RequestHistoryItemDTO[] requestHistoryItems;

    public RequestDTO(long Id, RequestItemDTO[] requestItemDtos, string currentStatus,
        RequestHistoryItemDTO[] requestHistoryItemDtos)
    {
        this.Id = Id;
        this.requestItems = requestItemDtos;
        this.currentStatus = currentStatus;
        this.requestHistoryItems = requestHistoryItemDtos;
    }



}
