using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DataContext _context;

        public BusinessRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Business>> GetAllAsync()
        {
            return await _context.Businesses
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<Business?> GetByIdAsync(int id)
        {
            return await _context.Businesses
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }

        public async Task AddAsync(Business business)
        {
            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Business business)
        {
            _context.Businesses.Update(business);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var business = await GetByIdAsync(id);
            if (business != null)
            {
                business.IsDeleted = true;
                await UpdateAsync(business);
            }
        }
    }
}
