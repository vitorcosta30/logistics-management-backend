using System.Threading.Tasks;

namespace MDGA.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}