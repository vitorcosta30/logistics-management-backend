using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestRepository : BaseRepository<Request>, IRequestRepository
{
    private readonly DbSet<Request> _objs;

    public RequestRepository(DbContextLM context) : base(context.Requests)
    {
        this._objs = context.Requests;
    }

    public async Task<List<Request>> getAllToBeProcessedAsync()
    {
        return await this._objs.Where(x => x.status.isToBeProcessed()).ToListAsync();

    }

    public async Task<List<RequestItemList>> getProductsInRequestAsync(long Id)
    {
        return await this._objs.Where(x => x.Id == Id).Select(x =>  x.listOfItems ).ToListAsync();
    }
}