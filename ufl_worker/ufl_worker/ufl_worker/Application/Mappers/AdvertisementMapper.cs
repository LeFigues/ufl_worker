using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class AdvertisementMapper
    {
        public static AdvertisementDto ToDto(this Advertisement advertisement)
        {
            return new AdvertisementDto
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Type = advertisement.Type,
                Description = advertisement.Description,
                Date = advertisement.Date,
                UserId = advertisement.UserId,
                RegisterAt = advertisement.RegisterAt,
                IsDeleted = advertisement.IsDeleted
            };
        }

        public static Advertisement ToEntity(this AdvertisementDto advertisementDto)
        {
            return new Advertisement
            {
                Id = advertisementDto.Id,
                Title = advertisementDto.Title,
                Type = advertisementDto.Type,
                Description = advertisementDto.Description,
                Date = advertisementDto.Date,
                UserId = advertisementDto.UserId,
                RegisterAt = advertisementDto.RegisterAt,
                IsDeleted = advertisementDto.IsDeleted
            };
        }
    }
}
