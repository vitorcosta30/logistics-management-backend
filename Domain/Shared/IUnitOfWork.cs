using System.Threading.Tasks;

namespace logistics_management_backend.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}