using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;

namespace ufl_worker.Infrastructure.Repositories
{
    public class AdvertisementEmployeeRepository : IAdvertisementEmployeeRepository
    {
        private readonly DataContext _context;

        public AdvertisementEmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdvertisementEmployee>> GetAllAsync()
        {
            return await _context.AdvertisementEmployees
                .Include(ae => ae.Advertisement)
                .Include(ae => ae.Employee)
                .ToListAsync();
        }

        public async Task<AdvertisementEmployee?> GetByIdAsync(int id)
        {
            return await _context.AdvertisementEmployees
                .Include(ae => ae.Advertisement)
                .Include(ae => ae.Employee)
                .FirstOrDefaultAsync(ae => ae.Id == id);
        }

        public async Task AddAsync(AdvertisementEmployee advertisementEmployee)
        {
            await _context.AdvertisementEmployees.AddAsync(advertisementEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AdvertisementEmployee advertisementEmployee)
        {
            _context.AdvertisementEmployees.Update(advertisementEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var advertisementEmployee = await GetByIdAsync(id);
            if (advertisementEmployee != null)
            {
                _context.AdvertisementEmployees.Remove(advertisementEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
