using Microsoft.AspNetCore.Mvc;
using MovieGraph.Application.DTOs;
using MovieGraph.Application.Interfaces.Services;

namespace MovieGraph.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(
            IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyList<MovieDto>>> GetRecommendations(string userId, [FromQuery] int limit = 10, CancellationToken cancellationToken = default)
        {
            var recommendations =
                await _recommendationService.GetMovieRecommendations(
                    userId,
                    limit,
                    cancellationToken);

            return Ok(recommendations);
        }

    }
}
