using MovieGraph.Application.DTOs;

namespace MovieGraph.Application.Interfaces.Repositories
{
    public interface IMovieRelationshipRepository
    {
        Task AddActorToMovie(string movieId, string actorId, CancellationToken cancellationToken = default);

        Task AddDirectorToMovie(string movieId, string directorId, CancellationToken cancellationToken = default);

        Task AddGenreToMovie(string movieId, string genreId, CancellationToken cancellationToken = default);

        Task AddMovieToUser(string userId, string movieId, CancellationToken cancellationToken = default);

        Task<MovieRelationshipGraphDto> GetMovieRelationships(string movieId, CancellationToken cancellationToken = default);
    }
}
