using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                RolId = user.RolId,
                EmployeeId = user.EmployeeId,
                IsDeleted = user.IsDeleted
            };
        }

        public static User ToEntity(this UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
                RolId = dto.RolId,
                EmployeeId = dto.EmployeeId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
