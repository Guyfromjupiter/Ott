using Microsoft.EntityFrameworkCore;
using Ott.Models;

namespace Ott.Data
{
    public class SqlMovieRepo : IMovieRepository
    {
        private readonly OttContext _context;

        public SqlMovieRepo(OttContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<List<Movie>> SearchByTitleAsync(string title)
       {
            return await _context.Movies
            .Where(m => m.Title.Contains(title))
            .ToListAsync();
        }
    }
}