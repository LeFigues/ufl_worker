using ufl_worker.Application.DTOs;
using ufl_worker.Core.Entities;

namespace ufl_worker.Application.Mappers
{
    public static class AssignmentEmployeeMapper
    {
        public static AssignmentEmployeeDto ToDto(this AssignmentEmployee assignmentEmployee)
        {
            return new AssignmentEmployeeDto
            {
                Id = assignmentEmployee.Id,
                AssignmentId = assignmentEmployee.AssignmentId,
                EmployeeId = assignmentEmployee.EmployeeId,
                ReadAt = assignmentEmployee.ReadAt,
                TaskStart = assignmentEmployee.TaskStart,
                TaskFinish = assignmentEmployee.TaskFinish,
                IsFinished = assignmentEmployee.IsFinished,
                ResultInformation = assignmentEmployee.ResultInformation,
                IsDeleted = assignmentEmployee.IsDeleted
            };
        }

        public static AssignmentEmployee ToEntity(this AssignmentEmployeeDto dto)
        {
            return new AssignmentEmployee
            {
                Id = dto.Id,
                AssignmentId = dto.AssignmentId,
                EmployeeId = dto.EmployeeId,
                ReadAt = dto.ReadAt,
                TaskStart = dto.TaskStart,
                TaskFinish = dto.TaskFinish,
                IsFinished = dto.IsFinished,
                ResultInformation = dto.ResultInformation,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}
