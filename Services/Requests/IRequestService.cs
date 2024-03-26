using logistics_management_backend.DTO.Products;
using logistics_management_backend.DTO.Requests;

namespace logistics_management_backend.Services.Requests;

public interface IRequestService
{
    Task<List<RequestDTO>> getAllAsync();
    Task<List<RequestDTO>> getAllToBeProcessedAsync();
    Task<List<RequestItemDTO>> getProductsInRequestAsync(long Id);

    Task<RequestDTO> addRequest(RequestItemDTO[] dto);

}