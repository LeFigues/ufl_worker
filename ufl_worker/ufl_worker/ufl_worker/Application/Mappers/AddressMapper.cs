using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class AddressMapper
    {
        public static AddressDto ToDto(this Address address)
        {
            return new AddressDto
            {
                Id = address.Id,
                AddressName = address.AddressName,
                Direction = address.Direction,
                Reference = address.Reference,
                Lat = address.Lat,
                Long = address.Long,
                EmployeeId = address.EmployeeId,
                IsDeleted = address.IsDeleted
            };
        }

        public static Address ToEntity(this AddressDto addressDto)
        {
            return new Address
            {
                Id = addressDto.Id,
                AddressName = addressDto.AddressName,
                Direction = addressDto.Direction,
                Reference = addressDto.Reference,
                Lat = addressDto.Lat,
                Long = addressDto.Long,
                EmployeeId = addressDto.EmployeeId,
                IsDeleted = addressDto.IsDeleted
            };
        }
    }
}
