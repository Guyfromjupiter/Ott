using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace   Ott.Models
{
    public class Watchlist
    {
        [Key]
        public int  WatchListId { get; set; }
        [ForeignKey("Profile")]
        public int  ProfileId { get; set; }
        [ForeignKey("Movie")]
        public int  MovieId { get; set; }
        public Profile? Profile{get; set;}
        public Movie Movie{get; set;} = null!;
        public DateTime AddedAt {get; set;} = DateTime.UtcNow;
    }

}