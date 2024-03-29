using logistics_management_backend.DTO.Products;
using logistics_management_backend.DTO.Requests;

namespace logistics_management_backend.Services.Requests;

public interface IRequestService
{
    Task<List<RequestDTO>> getAllAsync();
    Task<List<RequestDTO>> getAllToBeProcessedAsync();
    Task<List<RequestItemDTO>> getProductsInRequestAsync(long Id);

    Task<RequestDTO> addRequest(RequestItemDTO[] dto);
    Task<RequestDTO> startProcessing(long id);
    
    Task<RequestDTO> sendRequest(long id);

    Task<RequestDTO> collectedItem(long idRequest, long idProduct);
    
    Task<RequestDTO> getRequestById(long id);





}