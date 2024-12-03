using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class ExpensesService
    {
        private readonly IExpensesRepository _repository;

        public ExpensesService(IExpensesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExpensesDto>> GetAllAsync()
        {
            var expenses = await _repository.GetAllAsync();
            return expenses.Select(e => e.ToDto());
        }

        public async Task<ExpensesDto?> GetByIdAsync(int id)
        {
            var expenses = await _repository.GetByIdAsync(id);
            return expenses?.ToDto();
        }

        public async Task AddAsync(ExpensesDto dto)
        {
            var expenses = dto.ToEntity();
            await _repository.AddAsync(expenses);
        }

        public async Task UpdateAsync(ExpensesDto dto)
        {
            var expenses = dto.ToEntity();
            await _repository.UpdateAsync(expenses);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
