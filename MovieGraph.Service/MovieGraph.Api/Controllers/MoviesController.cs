using Microsoft.AspNetCore.Mvc;
using MovieGraph.Application.DTOs;
using MovieGraph.Application.Interfaces.Services;

namespace MovieGraph.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRelationshipService _movieRelationshipService;
        public MoviesController(IMovieService movieService, IMovieRelationshipService movieRelationshipService)
        {
            _movieService = movieService;
            _movieRelationshipService = movieRelationshipService;
        }

        [HttpGet("GetMovies")]
        public async Task<ActionResult<IReadOnlyList<MovieDto>>> GetAll(CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetAllMovies(cancellationToken);
            return Ok(movies);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MovieDto>> GetById(string id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieById(id, cancellationToken);
            return Ok(movie);
        }

        [HttpGet("{id}/similar")]
        public async Task<ActionResult<IReadOnlyList<MovieDto>>> GetSimilar(string id, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetSimilarMovies(id, cancellationToken);
            return Ok(movies);
        }

        [HttpGet("{id}/relationships")]
        public async Task<ActionResult<MovieRelationshipGraphDto>> GetMovieRelationships(string id, CancellationToken cancellationToken)
        {
            var result = await _movieRelationshipService.GetMovieRelationships(id, cancellationToken);
            return Ok(result);
        }
    }
}
