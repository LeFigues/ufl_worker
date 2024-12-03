using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Core.Interfaces
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Business>> GetAllAsync();
        Task<Business?> GetByIdAsync(int id);
        Task AddAsync(Business business);
        Task UpdateAsync(Business business);
        Task DeleteAsync(int id);
    }
}
