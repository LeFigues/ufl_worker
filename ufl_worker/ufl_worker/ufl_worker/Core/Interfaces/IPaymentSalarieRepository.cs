using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Core.Interfaces
{
    public interface IPaymentSalarieRepository
    {
        Task<IEnumerable<PaymentSalarie>> GetAllAsync();
        Task<PaymentSalarie?> GetByIdAsync(int id);
        Task AddAsync(PaymentSalarie paymentSalarie);
        Task UpdateAsync(PaymentSalarie paymentSalarie);
        Task DeleteAsync(int id);
    }
}
