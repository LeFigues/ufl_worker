using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;

namespace ufl_worker.Infrastructure.Repositories
{
    public class AssignmentEmployeeRepository : IAssignmentEmployeeRepository
    {
        private readonly DataContext _context;

        public AssignmentEmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssignmentEmployee>> GetAllAsync()
        {
            return await _context.AssignmentEmployees
                .Include(ae => ae.Assignment)
                .Include(ae => ae.Employee)
                .Where(ae => !ae.IsDeleted)
                .ToListAsync();
        }

        public async Task<AssignmentEmployee?> GetByIdAsync(int id)
        {
            return await _context.AssignmentEmployees
                .Include(ae => ae.Assignment)
                .Include(ae => ae.Employee)
                .FirstOrDefaultAsync(ae => ae.Id == id && !ae.IsDeleted);
        }

        public async Task AddAsync(AssignmentEmployee assignmentEmployee)
        {
            await _context.AssignmentEmployees.AddAsync(assignmentEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AssignmentEmployee assignmentEmployee)
        {
            _context.AssignmentEmployees.Update(assignmentEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignmentEmployee = await GetByIdAsync(id);
            if (assignmentEmployee != null)
            {
                assignmentEmployee.IsDeleted = true;
                await UpdateAsync(assignmentEmployee);
            }
        }
    }
}
