namespace Ott.Dto
{
    public class PaymentResponseDTO
    {
        public int SubscriptionId{get; set;}
        public string? Plan {get; set;}
        public DateTime? StartDate { get; set; }
        public DateTime?  EndDate { get; set; }
        public string? Status {get; set;}
    }

}