using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                CI = employee.CI,
                Cellphone = employee.Cellphone,
                HireDate = employee.HireDate,
                FireDate = employee.FireDate,
                Salary = employee.Salary,
                UserId = employee.UserId,
                BranchId = employee.BranchId,
                PositionId = employee.PositionId,
                IsDeleted = employee.IsDeleted
            };
        }

        public static Employee ToEntity(this EmployeeDto dto)
        {
            return new Employee
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CI = dto.CI,
                Cellphone = dto.Cellphone,
                HireDate = dto.HireDate,
                FireDate = dto.FireDate,
                Salary = dto.Salary,
                UserId = dto.UserId,
                BranchId = dto.BranchId,
                PositionId = dto.PositionId,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
