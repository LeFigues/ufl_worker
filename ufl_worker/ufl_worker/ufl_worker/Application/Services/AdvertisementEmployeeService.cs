using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AdvertisementEmployeeService
    {
        private readonly IAdvertisementEmployeeRepository _repository;

        public AdvertisementEmployeeService(IAdvertisementEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdvertisementEmployeeDto>> GetAllAsync()
        {
            var advertisementEmployees = await _repository.GetAllAsync();
            return advertisementEmployees.Select(ae => ae.ToDto());
        }

        public async Task<AdvertisementEmployeeDto?> GetByIdAsync(int id)
        {
            var advertisementEmployee = await _repository.GetByIdAsync(id);
            return advertisementEmployee?.ToDto();
        }

        public async Task AddAsync(AdvertisementEmployeeDto dto)
        {
            var advertisementEmployee = dto.ToEntity();
            await _repository.AddAsync(advertisementEmployee);
        }

        public async Task UpdateAsync(AdvertisementEmployeeDto dto)
        {
            var advertisementEmployee = dto.ToEntity();
            await _repository.UpdateAsync(advertisementEmployee);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
