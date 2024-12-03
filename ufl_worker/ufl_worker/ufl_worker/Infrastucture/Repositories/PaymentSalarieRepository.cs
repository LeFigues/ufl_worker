using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;
using ufl_worker.Data;
using ufl_worker.Models;

namespace ufl_worker.Infrastructure.Repositories
{
    public class PaymentSalarieRepository : IPaymentSalarieRepository
    {
        private readonly DataContext _context;

        public PaymentSalarieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentSalarie>> GetAllAsync()
        {
            return await _context.PaymentSalaries
                .Include(p => p.Employee)
                .Include(p => p.User)
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<PaymentSalarie?> GetByIdAsync(int id)
        {
            return await _context.PaymentSalaries
                .Include(p => p.Employee)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task AddAsync(PaymentSalarie paymentSalarie)
        {
            await _context.PaymentSalaries.AddAsync(paymentSalarie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaymentSalarie paymentSalarie)
        {
            _context.PaymentSalaries.Update(paymentSalarie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paymentSalarie = await GetByIdAsync(id);
            if (paymentSalarie != null)
            {
                paymentSalarie.IsDeleted = true;
                await UpdateAsync(paymentSalarie);
            }
        }
    }
}
