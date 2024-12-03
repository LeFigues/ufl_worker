using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly DataContext _context;

        public AssignmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await GetByIdAsync(id);
            if (assignment != null)
            {
                assignment.IsDeleted = true;
                await UpdateAsync(assignment);
            }
        }
    }
}
