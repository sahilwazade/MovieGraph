using Microsoft.Extensions.Logging;
using MovieGraph.Application.DTOs;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Infrastructure.Queries;
using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly IDriver _driver;
        private readonly ILogger<RecommendationRepository> _logger;

        public RecommendationRepository(IDriver driver, ILogger<RecommendationRepository> logger)
        {
            _driver = driver;
            _logger = logger;
        }

        public async Task<IReadOnlyList<MovieDto>> GetMovieRecommendations(string userId, int limit = 10, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching movie recommendations for UserId: {UserId}, Limit: {Limit}", userId, limit);

            var result = await _driver
                .ExecutableQuery(
                    MovieRecomendationQueries.RecomendationQuery)
                .WithParameters(new
                {
                    userId
                })
                .ExecuteAsync(cancellationToken);

            _logger.LogInformation("Retrieved {Count} movie recommendations for UserId: {UserId}", result.Result.Count, userId);

            return result.Result
                .Take(limit)
                .Select(record => new MovieDto
                {
                    Id = record["id"].As<string>(),
                    Title = record["title"].As<string>(),
                    ReleaseYear = record["releaseYear"].As<int>(),
                    Rating = record["rating"].As<double>(),
                    Description = record["description"].As<string>(),
                    PosterUrl = record["posterUrl"].As<string>()
                })
                .ToList();
        }

    }
}
