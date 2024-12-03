using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AdvertisementService
    {
        private readonly IAdvertisementRepository _repository;

        public AdvertisementService(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdvertisementDto>> GetAllAsync()
        {
            var advertisements = await _repository.GetAllAsync();
            return advertisements.Select(a => a.ToDto());
        }

        public async Task<AdvertisementDto?> GetByIdAsync(int id)
        {
            var advertisement = await _repository.GetByIdAsync(id);
            return advertisement?.ToDto();
        }

        public async Task AddAsync(AdvertisementDto advertisementDto)
        {
            var advertisement = advertisementDto.ToEntity();
            await _repository.AddAsync(advertisement);
        }

        public async Task UpdateAsync(AdvertisementDto advertisementDto)
        {
            var advertisement = advertisementDto.ToEntity();
            await _repository.UpdateAsync(advertisement);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
