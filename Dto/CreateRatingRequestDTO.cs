namespace Ott.Dto
{
    public class CreateRatingRequestDTO
    {
        public int MovieId { get; set; }
        public int ProfileId { get; set; }
        public int ActingRating { get; set; }
        public int StoryRating { get; set; }
        public int ProductionRating { get; set; }
        public string? ReviewText { get; set; }
        
       
    }

}