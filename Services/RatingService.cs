using Ott.Data;
using Ott.Dto;
using Ott.Models;

namespace Ott.Services
{
    public class RatingService
{
    private readonly IRatingRepository _ratingRepo;

    public RatingService(IRatingRepository ratingRepo)
    {
        _ratingRepo = ratingRepo;
    }

    public async Task AddRating(CreateRatingRequestDTO dto)
    {
        var exists = await _ratingRepo.ExistsAsync(dto.ProfileId, dto.MovieId);
        if (exists)
            throw new Exception("Rating already exists");

        var rating = new Rating
        {
            MovieId = dto.MovieId,
            ProfileId = dto.ProfileId,
            ActingRating = dto.ActingRating,
            StoryRating = dto.StoryRating,
            ProductionRating = dto.ProductionRating,
            ReviewText = dto.ReviewText,
            OverallRating = CalculateOverall(dto.ActingRating, dto.StoryRating, dto.ProductionRating)
        };

        await _ratingRepo.AddAsync(rating);
    }

    public async Task<IEnumerable<Rating>> GetRatingsByMovie(int movieId)
    {
        return await _ratingRepo.GetByMoviesAsync(movieId);
    }   
    public double CalculateOverall(int acting, int story, int production)
    {
        return Math.Round((acting + story + production) / 3.0, 1);
    }
}
}