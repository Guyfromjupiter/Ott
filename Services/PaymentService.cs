using Ott.Data;
using Ott.Dto;
using Ott.Models;

namespace Ott.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepo;

        public PaymentService(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<Payment> CreateSubscription(int userId, CreatePaymentDTO dto)
        {
            var payment = new Payment
            {
                UserId = userId,
                PlanType = dto.PlanType,
                PaymentReferenceId = dto.PaymentReferenceId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                IsActive = true
            };

            return await _paymentRepo.AddAsync(payment);
        }

        public async Task<bool> GetSubscriptionStatus(int userId)
        {
            var subs = await _paymentRepo.GetByUserAsync(userId);

            return subs.Any(s =>
                s.IsActive &&
                s.EndDate > DateTime.UtcNow);
        }
    }
}