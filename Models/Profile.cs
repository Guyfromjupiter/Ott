using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ott.Models
{
    public class Profile
    {
        [Key]
        public int  ProfileId { get; set; }
        [Required]
        [MaxLength(250)]
        public String? Name { get; set; }
        [Required]
        public Boolean? IsKidsProfile { get; set; }
        [ForeignKey("User")]
        public int UserId {get; set;}
        public User? user {get; set;}
    }

}