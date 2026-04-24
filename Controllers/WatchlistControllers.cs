using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ott.Dto;
using Ott.Services;

[ApiController]
[Route("api/watchlist")]
[Authorize]
public class WatchlistController : ControllerBase
{
    private readonly WatchlistService _watchlistService;

    public WatchlistController(WatchlistService watchlistService)
    {
        _watchlistService = watchlistService;
    }

    // POST: /api/watchlist/add
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddWatchlistDTO dto)
    {
        await _watchlistService.AddToWatchlist(dto.ProfileId, dto.MovieId);
        return Ok("Added to watchlist");
    }

    // GET: /api/watchlist/{profileId}
    [HttpGet("{profileId}")]
    public async Task<IActionResult> Get(int profileId)
    {
        var result = await _watchlistService.GetWatchlist(profileId);
        return Ok(result);
    }

    // DELETE: /api/watchlist/remove?profileId=1&movieId=2
    [HttpDelete("remove")]
    public async Task<IActionResult> Remove([FromQuery] int profileId, [FromQuery] int movieId)
    {
        await _watchlistService.RemoveFromWatchlist(profileId, movieId);
        return Ok("Removed from watchlist");
    }
}