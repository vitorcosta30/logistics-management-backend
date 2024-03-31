using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Domain.Shared;

namespace logistics_management_backend.Infrastructure.Requests;

public interface IRequestRepository : IRepository<Request>
{
    public Task<List<Request>> getAllToBeProcessedAsync();
    public Task<List<Request>> getAllToBeReceivedAsync();

    public Task<List<RequestItemList>> getProductsInRequestAsync(long Id);

    public Task<int> getNumberToBeProcessed();

    public Task<int> getNumberOnCollection();

    public Task<int> getNumberSent();

    public Task<int> getNumberReceived();

    public Task<int> requestedOnDate(DateOnly date);

    public Task<int> onCollectionOnDate(DateOnly date);

    public Task<int> sentOnDate(DateOnly date);

    public Task<int> receivedOnDate(DateOnly date);











}