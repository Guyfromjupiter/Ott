using System.ComponentModel.DataAnnotations;


namespace Ott.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        [MaxLength(250)]
        public String? Language { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string? PosterUrl { get; set; }
        public List<Rating>? Ratings {get; set;}
        
    }
}