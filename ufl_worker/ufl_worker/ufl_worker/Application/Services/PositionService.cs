using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class PositionService
    {
        private readonly IPositionRepository _repository;

        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var positions = await _repository.GetAllAsync();
            return positions.Select(p => p.ToDto());
        }

        public async Task<PositionDto?> GetByIdAsync(int id)
        {
            var position = await _repository.GetByIdAsync(id);
            return position?.ToDto();
        }

        public async Task AddAsync(PositionDto dto)
        {
            var position = dto.ToEntity();
            await _repository.AddAsync(position);
        }

        public async Task UpdateAsync(PositionDto dto)
        {
            var position = dto.ToEntity();
            await _repository.UpdateAsync(position);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
