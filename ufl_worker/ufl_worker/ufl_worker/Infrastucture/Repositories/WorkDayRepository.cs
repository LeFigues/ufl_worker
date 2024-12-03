using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class WorkDayRepository : IWorkDayRepository
    {
        private readonly DataContext _context;

        public WorkDayRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkDay>> GetAllAsync()
        {
            return await _context.WorkDays
                .Include(w => w.Employee)
                .Include(w => w.PaymentSalarie)
                .Where(w => !w.IsDeleted)
                .ToListAsync();
        }

        public async Task<WorkDay?> GetByIdAsync(int id)
        {
            return await _context.WorkDays
                .Include(w => w.Employee)
                .Include(w => w.PaymentSalarie)
                .FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }

        public async Task AddAsync(WorkDay workDay)
        {
            await _context.WorkDays.AddAsync(workDay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkDay workDay)
        {
            _context.WorkDays.Update(workDay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workDay = await GetByIdAsync(id);
            if (workDay != null)
            {
                workDay.IsDeleted = true;
                await UpdateAsync(workDay);
            }
        }
    }
}
