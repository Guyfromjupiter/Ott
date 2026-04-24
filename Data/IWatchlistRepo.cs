using Ott.Models;

namespace Ott.Data
{
    public interface IWatchlistRepo
    {
        //GetByProfile and Exists
        Task AddAsync(Watchlist watchlist);
        Task RemoveAsync(int profileid, int movieid);
        Task<bool> ExistsAsync(int profileid, int movieid);
        Task<IEnumerable<Movie>> GetByProfileAsync(int profileid);
    }
}