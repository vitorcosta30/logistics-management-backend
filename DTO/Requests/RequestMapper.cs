
using logistics_management_backend.Domain.Requests;

namespace logistics_management_backend.DTO.Requests;

public class RequestMapper
{
    public static  RequestDTO toDTO(Request request)
    {
        return new RequestDTO(request.Id,RequestItemMapper.toDto(request.listOfItems), request.status.ToString(), RequestHistoryItemMapper.toDTO(request.status));

    } 
}