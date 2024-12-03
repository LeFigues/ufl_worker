using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Core.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<IEnumerable<Advertisement>> GetAllAsync();
        Task<Advertisement?> GetByIdAsync(int id);
        Task AddAsync(Advertisement advertisement);
        Task UpdateAsync(Advertisement advertisement);
        Task DeleteAsync(int id);
    }
}
