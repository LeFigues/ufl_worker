using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository _repository;

        public AssignmentService(IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAsync()
        {
            var assignments = await _repository.GetAllAsync();
            return assignments.Select(a => a.ToDto());
        }

        public async Task<AssignmentDto?> GetByIdAsync(int id)
        {
            var assignment = await _repository.GetByIdAsync(id);
            return assignment?.ToDto();
        }

        public async Task AddAsync(AssignmentDto dto)
        {
            var assignment = dto.ToEntity();
            await _repository.AddAsync(assignment);
        }

        public async Task UpdateAsync(AssignmentDto dto)
        {
            var assignment = dto.ToEntity();
            await _repository.UpdateAsync(assignment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
