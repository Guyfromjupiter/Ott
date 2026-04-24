using System.ComponentModel.DataAnnotations;

namespace Ott.Models
{
    public class User
    {
        [Key]
        public int  UserId { get; set; }
        public Payment? payment {get; set;}
        [Required]
        [EmailAddress]
        [MaxLength(250)]
        public String? Email { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        public List<Profile> Profiles {get; set;} = new();
    }

}