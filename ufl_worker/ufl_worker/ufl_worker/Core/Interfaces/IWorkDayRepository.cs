using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Core.Interfaces
{
    public interface IWorkDayRepository
    {
        Task<IEnumerable<WorkDay>> GetAllAsync();
        Task<WorkDay?> GetByIdAsync(int id);
        Task AddAsync(WorkDay workDay);
        Task UpdateAsync(WorkDay workDay);
        Task DeleteAsync(int id);
    }
}
