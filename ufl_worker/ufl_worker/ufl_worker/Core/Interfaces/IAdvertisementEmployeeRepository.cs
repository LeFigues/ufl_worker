using ufl_worker.Core.Entities;

namespace ufl_worker.Core.Interfaces
{
    public interface IAdvertisementEmployeeRepository
    {
        Task<IEnumerable<AdvertisementEmployee>> GetAllAsync();
        Task<AdvertisementEmployee?> GetByIdAsync(int id);
        Task AddAsync(AdvertisementEmployee advertisementEmployee);
        Task UpdateAsync(AdvertisementEmployee advertisementEmployee);
        Task DeleteAsync(int id);
    }
}
