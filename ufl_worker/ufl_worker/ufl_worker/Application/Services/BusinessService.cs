using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class BusinessService
    {
        private readonly IBusinessRepository _repository;

        public BusinessService(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusinessDto>> GetAllAsync()
        {
            var businesses = await _repository.GetAllAsync();
            return businesses.Select(b => b.ToDto());
        }

        public async Task<BusinessDto?> GetByIdAsync(int id)
        {
            var business = await _repository.GetByIdAsync(id);
            return business?.ToDto();
        }

        public async Task AddAsync(BusinessDto dto)
        {
            var business = dto.ToEntity();
            await _repository.AddAsync(business);
        }

        public async Task UpdateAsync(BusinessDto dto)
        {
            var business = dto.ToEntity();
            await _repository.UpdateAsync(business);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
