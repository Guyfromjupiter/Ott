using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ott.Dto;
using Ott.Services;

[ApiController]
[Route("api/ratings")]
[Authorize]
public class RatingController : ControllerBase
{
    private readonly RatingService _ratingService;

    public RatingController(RatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpPost]
    public async Task<IActionResult> AddRating(CreateRatingRequestDTO dto)
    {
        await _ratingService.AddRating(dto);
        return Ok("Rating added");
    }

    [HttpGet("movie/{movieId}")]
    public async Task<IActionResult> GetByMovie(int movieId)
    {
        return Ok(await _ratingService.GetRatingsByMovie(movieId));
    }


}