using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class AssignmentMapper
    {
        public static AssignmentDto ToDto(this Assignment assignment)
        {
            return new AssignmentDto
            {
                Id = assignment.Id,
                Title = assignment.Title,
                Register = assignment.Register,
                Expired = assignment.Expired,
                Description = assignment.Description,
                UserId = assignment.UserId,
                IsDeleted = assignment.IsDeleted
            };
        }

        public static Assignment ToEntity(this AssignmentDto dto)
        {
            return new Assignment
            {
                Id = dto.Id,
                Title = dto.Title,
                Register = dto.Register,
                Expired = dto.Expired,
                Description = dto.Description,
                UserId = dto.UserId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
