using System.ComponentModel.DataAnnotations;



namespace Ott.Models
{
    public class Payment
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int UserId{get; set;}
        public User? user{get; set;}
        [Required]
        public String? PlanType { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime?  EndDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int? PaymentReferenceId { get; set; }
      
        
    }
}