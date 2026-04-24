using Ott.Models;

namespace Ott.Data
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int Id);
        Task<List<Movie>> SearchByTitleAsync(string title);

    }
}