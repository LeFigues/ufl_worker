using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => u.ToDto());
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user?.ToDto();
        }

        public async Task AddAsync(UserDto dto)
        {
            var user = dto.ToEntity();
            await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = dto.ToEntity();
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
