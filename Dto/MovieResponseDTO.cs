namespace Ott.Dto
{
    public class MovieResponseDTO   
    {

        public int MovieId { get; set; }
        public String? Title { get; set; }
        public string? Genre { get; set; }
        public String? Language { get; set; }
        
        public string? PosterUrl { get; set; }
        public double AverageRating{get; set;}
    }
}