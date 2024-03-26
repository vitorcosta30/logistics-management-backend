using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using logistics_management_backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
        return await this.getAllObjects()
            .Where(x => x.status.currentStatus.status == Status.REQUESTED)
            .ToListAsync();
    }

    public async Task<List<RequestItemList>> getProductsInRequestAsync(long Id)
    {
        return await this._objs.Where(x => x.Id == Id).Select(x =>  x.listOfItems ).ToListAsync();
    }

    public override IIncludableQueryable<Request, ProductPosition> getAllObjects()
    {
        return this._objs.Include(prod => prod.status).ThenInclude(status => status.currentStatus)
            .Include(prod => prod.status).ThenInclude(status => status.previousStatus)
            .Include(prod => prod.listOfItems).ThenInclude(items => items.items)
            .ThenInclude(item => item.item).ThenInclude(prod => prod.position);
    }


}