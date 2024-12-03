using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class BusinessMapper
    {
        public static BusinessDto ToDto(this Business business)
        {
            return new BusinessDto
            {
                Id = business.Id,
                Ufl_ID = business.Ufl_ID,
                BusinessName = business.BusinessName,
                IsDeleted = business.IsDeleted
            };
        }

        public static Business ToEntity(this BusinessDto dto)
        {
            return new Business
            {
                Id = dto.Id,
                Ufl_ID = dto.Ufl_ID,
                BusinessName = dto.BusinessName,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
