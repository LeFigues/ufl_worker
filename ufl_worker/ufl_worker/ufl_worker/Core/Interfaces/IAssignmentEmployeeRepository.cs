using ufl_worker.Core.Entities;

namespace ufl_worker.Core.Interfaces
{
    public interface IAssignmentEmployeeRepository
    {
        Task<IEnumerable<AssignmentEmployee>> GetAllAsync();
        Task<AssignmentEmployee?> GetByIdAsync(int id);
        Task AddAsync(AssignmentEmployee assignmentEmployee);
        Task UpdateAsync(AssignmentEmployee assignmentEmployee);
        Task DeleteAsync(int id);
    }
}
