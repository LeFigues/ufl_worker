using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class BranchService
    {
        private readonly IBranchRepository _repository;

        public BranchService(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchDto>> GetAllAsync()
        {
            var branches = await _repository.GetAllAsync();
            return branches.Select(b => b.ToDto());
        }

        public async Task<BranchDto?> GetByIdAsync(int id)
        {
            var branch = await _repository.GetByIdAsync(id);
            return branch?.ToDto();
        }

        public async Task AddAsync(BranchDto dto)
        {
            var branch = dto.ToEntity();
            await _repository.AddAsync(branch);
        }

        public async Task UpdateAsync(BranchDto dto)
        {
            var branch = dto.ToEntity();
            await _repository.UpdateAsync(branch);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
