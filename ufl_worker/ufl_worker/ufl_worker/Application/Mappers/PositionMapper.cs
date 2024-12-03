using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class PositionMapper
    {
        public static PositionDto ToDto(this Position position)
        {
            return new PositionDto
            {
                Id = position.Id,
                PositionName = position.PositionName,
                Description = position.Description,
                IsDeleted = position.IsDeleted
            };
        }

        public static Position ToEntity(this PositionDto dto)
        {
            return new Position
            {
                Id = dto.Id,
                PositionName = dto.PositionName,
                Description = dto.Description,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
