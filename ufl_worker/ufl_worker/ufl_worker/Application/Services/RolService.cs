using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class RolService
    {
        private readonly IRolRepository _repository;

        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RolDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(r => r.ToDto());
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            return rol?.ToDto();
        }

        public async Task AddAsync(RolDto dto)
        {
            var rol = dto.ToEntity();
            await _repository.AddAsync(rol);
        }

        public async Task UpdateAsync(RolDto dto)
        {
            var rol = dto.ToEntity();
            await _repository.UpdateAsync(rol);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
