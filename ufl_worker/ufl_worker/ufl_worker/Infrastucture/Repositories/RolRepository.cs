using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly DataContext _context;

        public RolRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Roles
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

        public async Task AddAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await GetByIdAsync(id);
            if (rol != null)
            {
                rol.IsDeleted = true;
                await UpdateAsync(rol);
            }
        }
    }
}
