using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class PaymentSalarieService
    {
        private readonly IPaymentSalarieRepository _repository;

        public PaymentSalarieService(IPaymentSalarieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaymentSalarieDto>> GetAllAsync()
        {
            var paymentSalaries = await _repository.GetAllAsync();
            return paymentSalaries.Select(p => p.ToDto());
        }

        public async Task<PaymentSalarieDto?> GetByIdAsync(int id)
        {
            var paymentSalarie = await _repository.GetByIdAsync(id);
            return paymentSalarie?.ToDto();
        }

        public async Task AddAsync(PaymentSalarieDto dto)
        {
            var paymentSalarie = dto.ToEntity();
            await _repository.AddAsync(paymentSalarie);
        }

        public async Task UpdateAsync(PaymentSalarieDto dto)
        {
            var paymentSalarie = dto.ToEntity();
            await _repository.UpdateAsync(paymentSalarie);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
