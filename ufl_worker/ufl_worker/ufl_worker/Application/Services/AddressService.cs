using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.Select(a => a.ToDto());
        }

        public async Task<AddressDto?> GetByIdAsync(int id)
        {
            var address = await _repository.GetByIdAsync(id);
            return address?.ToDto();
        }

        public async Task AddAsync(AddressDto addressDto)
        {
            var address = addressDto.ToEntity();
            await _repository.AddAsync(address);
        }

        public async Task UpdateAsync(AddressDto addressDto)
        {
            var address = addressDto.ToEntity();
            await _repository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
