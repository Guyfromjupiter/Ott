using Microsoft.EntityFrameworkCore;
using Ott.Models;

namespace Ott.Data
{
    public class SqlpaymentRepo : IPaymentRepository
    {
         private readonly OttContext _context;

    public SqlpaymentRepo(OttContext context)
    {
        _context = context;
    }

    public async Task<Payment> AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<IEnumerable<Payment>> GetByUserAsync(int userId)
    {
        return await _context.Payments
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.StartDate).ToListAsync();
    }

    public async Task<Payment?> GetActiveByUserAsync(int userId)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.IsActive &&
                s.EndDate > DateTime.UtcNow);
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    }
}