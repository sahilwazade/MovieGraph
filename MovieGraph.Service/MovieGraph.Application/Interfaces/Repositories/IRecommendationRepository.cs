using MovieGraph.Application.DTOs;
using MovieGraph.Domain.Entities;

namespace MovieGraph.Application.Interfaces.Repositories
{
    public interface IRecommendationRepository
    {
        Task<IReadOnlyList<MovieDto>> GetMovieRecommendations(string userId, int limit = 10, CancellationToken cancellationToken = default);
    }
}
