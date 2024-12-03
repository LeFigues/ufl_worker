using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class ExpensesMapper
    {
        public static ExpensesDto ToDto(this Expenses expenses)
        {
            return new ExpensesDto
            {
                Id = expenses.Id,
                Title = expenses.Title,
                Description = expenses.Description,
                Amount = expenses.Amount,
                BranchId = expenses.BranchId,
                UserId = expenses.UserId,
                RegisterAt = expenses.RegisterAt,
                IsDeleted = expenses.IsDeleted
            };
        }

        public static Expenses ToEntity(this ExpensesDto dto)
        {
            return new Expenses
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Amount = dto.Amount,
                BranchId = dto.BranchId,
                UserId = dto.UserId,
                RegisterAt = dto.RegisterAt,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
