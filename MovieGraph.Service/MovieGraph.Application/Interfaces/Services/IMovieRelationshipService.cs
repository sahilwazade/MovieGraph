using MovieGraph.Application.DTOs;

namespace MovieGraph.Application.Interfaces.Services
{
    public interface IMovieRelationshipService
    {
        Task<MovieRelationshipGraphDto> GetMovieRelationships(string movieId, CancellationToken cancellationToken = default);
    }
}
