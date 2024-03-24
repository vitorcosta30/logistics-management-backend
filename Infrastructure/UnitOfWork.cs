using MDGA.Domain.Shared;

namespace logistics_management_backend.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContextLM _context;

    public UnitOfWork(DbContextLM context)
    {
        this._context = context;
    }

    public async Task<int> CommitAsync()
    {
        return await this._context.SaveChangesAsync();
    }
    
}