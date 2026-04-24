using Ott.Data;
using Ott.Models;
namespace Ott.Services
{
    public class WatchlistService
{
    private readonly IWatchlistRepo _watchlistRepo;

    public WatchlistService(IWatchlistRepo watchlistRepo)
    {
        _watchlistRepo = watchlistRepo;
    }

    public async Task AddToWatchlist(int profileId, int movieId)
    {
        var exists = await _watchlistRepo.ExistsAsync(profileId, movieId);
        if (exists)
            throw new Exception("Movie already in watchlist");

        var item = new Watchlist
        {
            ProfileId = profileId,
            MovieId = movieId
        };

        await _watchlistRepo.AddAsync(item);
    }

    public async Task RemoveFromWatchlist(int profileId, int movieId)
    {
        await _watchlistRepo.RemoveAsync(profileId, movieId);
    }

    public async Task<IEnumerable<Movie>>  GetWatchlist(int profileId)
    {
        return await _watchlistRepo.GetByProfileAsync(profileId);
    }
}
}