using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AssignmentEmployeeService
    {
        private readonly IAssignmentEmployeeRepository _repository;

        public AssignmentEmployeeService(IAssignmentEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssignmentEmployeeDto>> GetAllAsync()
        {
            var assignmentEmployees = await _repository.GetAllAsync();
            return assignmentEmployees.Select(ae => ae.ToDto());
        }

        public async Task<AssignmentEmployeeDto?> GetByIdAsync(int id)
        {
            var assignmentEmployee = await _repository.GetByIdAsync(id);
            return assignmentEmployee?.ToDto();
        }

        public async Task AddAsync(AssignmentEmployeeDto dto)
        {
            var assignmentEmployee = dto.ToEntity();
            await _repository.AddAsync(assignmentEmployee);
        }

        public async Task UpdateAsync(AssignmentEmployeeDto dto)
        {
            var assignmentEmployee = dto.ToEntity();
            await _repository.UpdateAsync(assignmentEmployee);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
