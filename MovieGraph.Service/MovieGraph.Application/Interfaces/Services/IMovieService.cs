using MovieGraph.Application.DTOs;

namespace MovieGraph.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IReadOnlyList<MovieDto>> GetAllMovies(CancellationToken cancellationToken = default);
        Task<MovieDto?> GetMovieById(string movieId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MovieDto>> GetSimilarMovies(string movieId, CancellationToken cancellationToken = default);
        Task<MovieDto> CreateMovie(MovieDto movie, CancellationToken cancellationToken = default);
    }
}
