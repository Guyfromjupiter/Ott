namespace Ott.Dto
{
    public class CreatePaymentDTO
    {
        public string? PlanType {get; set;}
        public decimal Amount {get; set;}
        public int? PaymentReferenceId{get; set;}
    }

}