namespace Ott.Dto
{
    public class SubscriptionStatusResponseDTO
    {
        public string? Plan {get; set;}
        public bool IsActive {get; set;}
        public DateTime? ExpiryDate {get; set;}
    }

}