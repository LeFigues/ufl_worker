using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;

namespace ufl_worker.Infrastructure.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly DataContext _context;

        public ExpensesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expenses>> GetAllAsync()
        {
            return await _context.Expenses
                .Include(e => e.Branch)
                .Include(e => e.User)
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Expenses?> GetByIdAsync(int id)
        {
            return await _context.Expenses
                .Include(e => e.Branch)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task AddAsync(Expenses expenses)
        {
            await _context.Expenses.AddAsync(expenses);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expenses expenses)
        {
            _context.Expenses.Update(expenses);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expenses = await GetByIdAsync(id);
            if (expenses != null)
            {
                expenses.IsDeleted = true;
                await UpdateAsync(expenses);
            }
        }
    }
}
