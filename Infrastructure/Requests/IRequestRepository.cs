using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Infrastructure.Requests;

public interface IRequestRepository : IRepository<Request>
{
    public Task<List<Request>> getAllToBeProcessedAsync();
    public Task<List<RequestItemList>> getProductsInRequestAsync(long Id);
    


}