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
    
    public async Task<List<Request>> getAllToBeReceivedAsync()
    {
        return await this.getAllObjects()
            .Where(x => x.status.currentStatus.status == Status.SENT)
            .ToListAsync();
    }

    public async Task<List<RequestItemList>> getProductsInRequestAsync(long Id)
    {
        return await this._objs.Where(x => x.Id == Id).Select(x =>  x.listOfItems ).ToListAsync();
    }

    public async Task<int> getNumberToBeProcessed()
    {
        return  this._objs.Count(req => req.status.currentStatus.status == Status.REQUESTED);
    }
    public async Task<int> getNumberOnCollection()
    {
        return  this._objs.Count(req => req.status.currentStatus.status == Status.COLLECTION);
    }
    public async Task<int> getNumberSent()
    {
        return  this._objs.Count(req => req.status.currentStatus.status == Status.SENT);
    }
    public async Task<int> getNumberReceived()
    {
        return  this._objs.Count(req => req.status.currentStatus.status == Status.RECEIVED);
    }

    public async Task<int> requestedOnDate(DateOnly date)
    {
        DateTime startDate = date.ToDateTime(new TimeOnly(0));
        DateTime endDate = startDate.AddDays(1);
        return this._objs.SelectMany(req =>
            req.status.previousStatus).Count(st => st.status == Status.REQUESTED && st.startDate >= startDate && st.startDate < endDate);
        //return  this._objs.Count(req =>  req.status.previousStatus.Exists(st => st.status == Status.REQUESTED && DateOnly.FromDateTime(st.startDate) == date));
    }
    
    public async Task<int> onCollectionOnDate(DateOnly date)
    {
        DateTime startDate = date.ToDateTime(new TimeOnly(0));
        DateTime endDate = startDate.AddDays(1);
        return this._objs.SelectMany(req =>
            req.status.previousStatus).Count(st => st.status == Status.COLLECTION && st.startDate >= startDate && st.startDate < endDate);
        //return  this._objs.Count(req =>  req.status.previousStatus.Exists(st => st.status == Status.COLLECTION && DateOnly.FromDateTime(st.startDate) == date));
    }
    
    public async Task<int> sentOnDate(DateOnly date)
    {
        DateTime startDate = date.ToDateTime(new TimeOnly(0));
        DateTime endDate = startDate.AddDays(1);
        return this._objs.SelectMany(req =>
            req.status.previousStatus).Count(st => st.status == Status.SENT && st.startDate >= startDate && st.startDate < endDate);
        //return  this._objs.Count(req =>  req.status.previousStatus.Exists(st => st.status == Status.SENT && DateOnly.FromDateTime(st.startDate) == date));
    }
    public async Task<int> receivedOnDate(DateOnly date)
    {
        DateTime startDate = date.ToDateTime(new TimeOnly(0));
        DateTime endDate = startDate.AddDays(1);
        return this._objs.SelectMany(req =>
            req.status.previousStatus).Count(st => st.status == Status.RECEIVED && st.startDate >= startDate && st.startDate < endDate);
        //return  this._objs.Count(req =>  req.status.previousStatus.Exists(st => st.status == Status.RECEIVED && DateOnly.FromDateTime(st.startDate) == date));
    }


    public override IIncludableQueryable<Request, ProductPosition> getAllObjects()
    {
        return this._objs.Include(prod => prod.status).ThenInclude(status => status.currentStatus)
            .Include(prod => prod.status).ThenInclude(status => status.previousStatus)
            .Include(prod => prod.listOfItems).ThenInclude(items => items.items)
            .ThenInclude(item => item.item).ThenInclude(prod => prod.position);
    }


}