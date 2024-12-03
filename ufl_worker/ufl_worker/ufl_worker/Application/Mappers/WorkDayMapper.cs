using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class WorkDayMapper
    {
        public static WorkDayDto ToDto(this WorkDay workDay)
        {
            return new WorkDayDto
            {
                Id = workDay.Id,
                Start = workDay.Start,
                End = workDay.End,
                Salary = workDay.Salary,
                IsCounted = workDay.IsCounted,
                Lat = workDay.Lat,
                Lon = workDay.Lon,
                EmployeeId = workDay.EmployeeId,
                PaymentSalarieId = workDay.PaymentSalarieId,
                IsDeleted = workDay.IsDeleted
            };
        }

        public static WorkDay ToEntity(this WorkDayDto dto)
        {
            return new WorkDay
            {
                Id = dto.Id,
                Start = dto.Start,
                End = dto.End,
                Salary = dto.Salary,
                IsCounted = dto.IsCounted,
                Lat = dto.Lat,
                Lon = dto.Lon,
                EmployeeId = dto.EmployeeId,
                PaymentSalarieId = dto.PaymentSalarieId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
