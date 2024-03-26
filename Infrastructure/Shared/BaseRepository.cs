using logistics_management_backend.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace logistics_management_backend.Infrastructure.Shared;

public abstract class BaseRepository<T> : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _objs;
    public BaseRepository(DbSet<T> objs)
    {
        this._objs = objs ?? throw new ArgumentNullException(nameof(objs));
        
    }


    public async Task<List<T>> GetAllAsync()
    {
        return await getAllObjects().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await getAllObjects()
            .Where(x => id.Equals(x.Id)).FirstOrDefaultAsync();
        
    }

    public async Task<List<T>> GetByIdsAsync(List<long> ids)
    {
        return await getAllObjects().Where(x => ids.Contains(x.Id)).ToListAsync();
        
    }

    public async Task<T> AddAsync(T obj)
    {
        var ret = await this._objs.AddAsync(obj);
        return ret.Entity;
        
    }

    public async void Remove(T obj)
    {
        this._objs.Remove(obj);
    }

    public abstract IIncludableQueryable<T, Object> getAllObjects();

}