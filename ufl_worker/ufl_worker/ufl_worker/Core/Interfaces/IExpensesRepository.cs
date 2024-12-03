using ufl_worker.Core.Entities;

namespace ufl_worker.Core.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<Expenses>> GetAllAsync();
        Task<Expenses?> GetByIdAsync(int id);
        Task AddAsync(Expenses expenses);
        Task UpdateAsync(Expenses expenses);
        Task DeleteAsync(int id);
    }
}
