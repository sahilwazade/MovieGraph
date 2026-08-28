using MovieGraph.Domain.Entities;

namespace MovieGraph.Application.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IReadOnlyList<Movie>> GetAllMovies(CancellationToken cancellationToken = default);
        Task<Movie?> GetMovieById(string movieId, CancellationToken cancellationToken = default);
        Task<Movie> CreateMovie(Movie movie, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Movie>> GetSimilarMovies(string movieId, CancellationToken cancellationToken = default);
    }
}
