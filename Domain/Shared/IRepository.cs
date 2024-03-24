using System.Collections.Generic;
using System.Threading.Tasks;

namespace logistics_management_backend.Domain.Shared
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetByIdsAsync(List<long> ids);
        Task<T> AddAsync(T obj);
        void Remove(T obj);
    }
}