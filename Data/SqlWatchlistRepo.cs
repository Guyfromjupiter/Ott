using Ott.Models;
using Microsoft.EntityFrameworkCore;
namespace Ott.Data
{
    public class SqlWatchlistRepo : IWatchlistRepo
    {
        private readonly OttContext _context;

        public SqlWatchlistRepo(OttContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Watchlist watchlist)
        {
            await _context.Watchlists.AddAsync(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int profileid, int movieid)
        {
            return await _context.Watchlists.AnyAsync(w=> w.ProfileId == profileid && w.MovieId == movieid);
        }

        public async Task<IEnumerable<Movie>> GetByProfilAsync(int profileid)
        {
            return await _context.Watchlists.Where(w=> w.ProfileId == profileid).Select(w => w.Movie).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetByProfileAsync(int profileid)
{
    return await _context.Watchlists
        .Where(w => w.ProfileId == profileid)
        .Select(w => w.Movie)
        .ToListAsync();
}

        public async Task RemoveAsync(int profileid, int movieid)
        {
            var item = await _context.Watchlists.FirstOrDefaultAsync(w => w.ProfileId == profileid && w.MovieId == movieid);
            if(item != null)
            {
                _context.Watchlists.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}