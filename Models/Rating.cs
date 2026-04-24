using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ott.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Movie? movie {get; set;}
        public Profile? profiles{get; set;}
        [Required]
        [MaxLength(250)]
        public int? ActingRating { get; set; }
        [Required]
        public int? StoryRating { get; set; }
        [Required]
        public int? ProductionRating { get; set; }
        [Required]
        public double OverallRating { get; set; }
        [Required]
        public string? ReviewText { get; set; }
        
       
        
    }
}