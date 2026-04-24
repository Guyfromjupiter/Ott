using Microsoft.AspNetCore.Mvc;
using Ott.Dto;
using Ott.Services;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _movieService.GetAllMovies());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _movieService.GetMovieById(id);

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        return Ok(await _movieService.SearchMovies(query));
    }


}