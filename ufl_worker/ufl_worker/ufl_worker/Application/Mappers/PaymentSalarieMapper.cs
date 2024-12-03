using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Application.Mappers
{
    public static class PaymentSalarieMapper
    {
        public static PaymentSalarieDto ToDto(this PaymentSalarie paymentSalarie)
        {
            return new PaymentSalarieDto
            {
                Id = paymentSalarie.Id,
                EmployeeId = paymentSalarie.EmployeeId,
                DateOfPayment = paymentSalarie.DateOfPayment,
                TotalHours = paymentSalarie.TotalHours,
                ExtraAmount = paymentSalarie.ExtraAmount,
                Description = paymentSalarie.Description,
                Amount = paymentSalarie.Amount,
                UserId = paymentSalarie.UserId,
                IsDeleted = paymentSalarie.IsDeleted
            };
        }

        public static PaymentSalarie ToEntity(this PaymentSalarieDto dto)
        {
            return new PaymentSalarie
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                DateOfPayment = dto.DateOfPayment,
                TotalHours = dto.TotalHours,
                ExtraAmount = dto.ExtraAmount,
                Description = dto.Description,
                Amount = dto.Amount,
                UserId = dto.UserId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
