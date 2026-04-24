using Microsoft.EntityFrameworkCore;
using Ott.Models;

namespace Ott.Data
{
    public class SqlRatingRepo : IRatingRepository
    {
        private readonly OttContext _context;

        public SqlRatingRepo(OttContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int profileid, int movieid)
        {
            return await _context.Ratings.AnyAsync(r=> r.ProfileId == profileid && r.MovieId == movieid);
        }

public async Task<double> GetAverageRatingAsync(int movieId)
{
    var ratings = await _context.Ratings
        .Where(r => r.MovieId == movieId)
        .ToListAsync();

    if (!ratings.Any())
        return 0;

    return Math.Round(ratings.Average(r => r.OverallRating), 1);
}

        public async Task<IEnumerable<Rating>> GetByMoviesAsync(int movieid)
        {
            return await _context.Ratings.Where(r=> r.MovieId == movieid).ToListAsync();
        }
    }
}