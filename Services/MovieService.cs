using Ott.Data;
using Ott.Dto;
using Ott.Models;

namespace Ott.Services
{
   public class MovieService
{
    private readonly IMovieRepository _movieRepo;
    private readonly IRatingRepository _ratingRepo;

    public MovieService(IMovieRepository movieRepo, IRatingRepository ratingRepo)
    {
        _movieRepo = movieRepo;
        _ratingRepo = ratingRepo;
    }

    public async Task<List<MovieResponseDTO>> GetAllMovies()
    {
        var movies = await _movieRepo.GetAllAsync();

        var result = new List<MovieResponseDTO>();

        foreach (var movie in movies)
        {
            var avg = await _ratingRepo.GetAverageRatingAsync(movie.MovieId);

            result.Add(new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                PosterUrl = movie.PosterUrl,
                AverageRating = avg
            });
        }

        return result;
    }

    public async Task<Movie?> GetMovieById(int id)
    {
        return await _movieRepo.GetByIdAsync(id);
    }

    public async Task<List<Movie>> SearchMovies(string query)
    {
        return await _movieRepo.SearchByTitleAsync(query);
    }


} 
}