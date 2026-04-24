using Ott.Models;

namespace Ott.Data
{
    public interface IPaymentRepository
    {
        //payment == subscription

    Task<Payment> AddAsync(Payment payment);

    Task<IEnumerable<Payment>> GetByUserAsync(int userId);
    Task<Payment?> GetActiveByUserAsync(int userId);
    Task UpdateAsync(Payment payment);
    }
}