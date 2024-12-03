using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => e.ToDto());
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee?.ToDto();
        }

        public async Task AddAsync(EmployeeDto dto)
        {
            var employee = dto.ToEntity();
            await _repository.AddAsync(employee);
        }

        public async Task UpdateAsync(EmployeeDto dto)
        {
            var employee = dto.ToEntity();
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
