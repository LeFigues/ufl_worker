using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class AdvertisementEmployeeMapper
    {
        public static AdvertisementEmployeeDto ToDto(this AdvertisementEmployee advertisementEmployee)
        {
            return new AdvertisementEmployeeDto
            {
                Id = advertisementEmployee.Id,
                AdvertisementId = advertisementEmployee.AdvertisementId,
                EmployeeId = advertisementEmployee.EmployeeId,
                ReadAt = advertisementEmployee.ReadAt,
                IsChecked = advertisementEmployee.IsChecked
            };
        }

        public static AdvertisementEmployee ToEntity(this AdvertisementEmployeeDto dto)
        {
            return new AdvertisementEmployee
            {
                Id = dto.Id,
                AdvertisementId = dto.AdvertisementId,
                EmployeeId = dto.EmployeeId,
                ReadAt = dto.ReadAt,
                IsChecked = dto.IsChecked
            };
        }
    }
}
