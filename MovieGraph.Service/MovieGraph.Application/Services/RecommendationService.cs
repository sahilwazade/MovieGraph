using MovieGraph.Application.DTOs;
using MovieGraph.Application.Exceptions;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Application.Interfaces.Services;


namespace MovieGraph.Application.Services
{
    public sealed class RecommendationService: IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(
            IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task<IReadOnlyList<MovieDto>> GetMovieRecommendations(string userId, int limit = 10, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new BadRequestException(
                    "UserId is required.");
            }

            if (limit <= 0)
            {
                throw new BadRequestException(
                    "Limit must be greater than 0.");
            }

            return await _recommendationRepository
                .GetMovieRecommendations(
                    userId,
                    limit,
                    cancellationToken);
        }

    }
}
