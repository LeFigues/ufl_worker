using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class RolMapper
    {
        public static RolDto ToDto(this Rol rol)
        {
            return new RolDto
            {
                Id = rol.Id,
                RolName = rol.RolName,
                Description = rol.Description,
                IsDeleted = rol.IsDeleted
            };
        }

        public static Rol ToEntity(this RolDto dto)
        {
            return new Rol
            {
                Id = dto.Id,
                RolName = dto.RolName,
                Description = dto.Description,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
