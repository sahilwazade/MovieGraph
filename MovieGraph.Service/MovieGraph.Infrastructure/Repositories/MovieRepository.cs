using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Domain.Entities;
using MovieGraph.Infrastructure.Queries;
using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Repositories
{
    public sealed class MovieRepository: IMovieRepository
    {
        private readonly IDriver _driver;

        public MovieRepository(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<IReadOnlyList<Movie>> GetAllMovies(CancellationToken cancellationToken = default)
        {
                var result = await _driver
                .ExecutableQuery(MovieQueries.GetAll)
                .ExecuteAsync();

                return result.Result
                    .Select(MapMovie)
                    .ToList();
        }

        public async Task<Movie?> GetMovieById(string movieId, CancellationToken cancellationToken = default)
        {
            var result = await _driver
                .ExecutableQuery(MovieQueries.GetById)
                .WithParameters(new
                {
                    movieId
                })
                .ExecuteAsync();

            var record = result.Result.SingleOrDefault();

            return record is null ? null : MapMovie(record);
        }

        public async Task<Movie> CreateMovie(Movie movie, CancellationToken cancellationToken = default)
        {
            var result = await _driver
                .ExecutableQuery(MovieQueries.Create)
                .WithParameters(new
                {
                    movie.Id,
                    movie.Title,
                    movie.ReleaseYear,
                    movie.Rating,
                    movie.Description
                })
                .ExecuteAsync();

            var record = result.Result.Single();

            return MapMovie(record);
        }

        public async Task<IReadOnlyList<Movie>> GetSimilarMovies(string movieId, CancellationToken cancellationToken = default)
        {
            var result = await _driver
                .ExecutableQuery(MovieQueries.GetSimilarMovies)
                .WithParameters(new
                {
                    movieId
                }).ExecuteAsync();

            return result.Result
                .Select(MapMovie)
                .ToList();
        }

        private static Movie MapMovie(IRecord record)
        {
            return new Movie
            {
                Id = record["id"].As<string>(),
                Title = record["title"].As<string>(),
                ReleaseYear = record["releaseYear"].As<int>(),
                Rating = record["rating"].As<double>(),
                Description = record["description"].As<string>(),
                PosterUrl = record["posterUrl"].As<string>()
            };
        }
    }
}
