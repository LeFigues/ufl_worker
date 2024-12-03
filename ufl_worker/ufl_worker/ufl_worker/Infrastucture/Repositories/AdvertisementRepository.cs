using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly DataContext _context;

        public AdvertisementRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advertisement>> GetAllAsync()
        {
            return await _context.Advertisements
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<Advertisement?> GetByIdAsync(int id)
        {
            return await _context.Advertisements
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task AddAsync(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var advertisement = await GetByIdAsync(id);
            if (advertisement != null)
            {
                advertisement.IsDeleted = true;
                await UpdateAsync(advertisement);
            }
        }
    }
}
