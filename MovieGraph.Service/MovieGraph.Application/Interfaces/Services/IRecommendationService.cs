using MovieGraph.Application.DTOs;

namespace MovieGraph.Application.Interfaces.Services
{
    public interface IRecommendationService
    {
        Task<IReadOnlyList<MovieDto>> GetMovieRecommendations(string userId, int limit = 10, CancellationToken cancellationToken = default);
    }
}
