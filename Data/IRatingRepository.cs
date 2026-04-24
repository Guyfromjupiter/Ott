using Ott.Models;

namespace Ott.Data
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetByMoviesAsync(int movieid);
        Task<bool> ExistsAsync(int profileid, int movieid);
        Task AddAsync(Rating rating);
        Task<double> GetAverageRatingAsync(int movieId);
    }
}