using MovieGraph.Application.DTOs;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Infrastructure.Queries;
using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Repositories
{
    public sealed class MovieRelationshipRepository: IMovieRelationshipRepository
    {
        private readonly IDriver _driver;

        public MovieRelationshipRepository(IDriver driver)
        {
            _driver = driver;
        }

        public async Task AddActorToMovie(string movieId, string actorId, CancellationToken cancellationToken = default)
        {
            await _driver
                .ExecutableQuery(RelationshipQueries.AddActorToMovie)
                .WithParameters(new
                {
                    movieId,
                    actorId
                })
                .ExecuteAsync();
        }

        public async Task AddDirectorToMovie(string movieId, string directorId, CancellationToken cancellationToken = default)
        {
            await _driver
                .ExecutableQuery(RelationshipQueries.AddDirectorToMovie)
                .WithParameters(new
                {
                    movieId,
                    directorId
                })
                .ExecuteAsync();
        }

        public async Task AddGenreToMovie(string movieId, string genreId, CancellationToken cancellationToken = default)
        {
            await _driver
                .ExecutableQuery(RelationshipQueries.AddGenreToMovie)
                .WithParameters(new
                {
                    movieId,
                    genreId
                })
                .ExecuteAsync();
        }

        public async Task AddMovieToUser(string userId, string movieId, CancellationToken cancellationToken = default)
        {
            await _driver
                .ExecutableQuery(RelationshipQueries.AddMovieToUser)
                .WithParameters(new
                {
                    userId,
                    movieId
                })
                .ExecuteAsync();
        }

        public async Task<MovieRelationshipGraphDto> GetMovieRelationships(string movieId, CancellationToken cancellationToken = default)
        {
            var result = await _driver
                .ExecutableQuery(
                    RelationshipQueries.GetMovieRelationships)
                .WithParameters(new
                {
                    movieId
                })
                .ExecuteAsync();

            var nodes = new Dictionary<string, MovieRelationshipNodeDto>();

            foreach (var record in result.Result)
            {
                var movieIdValue = record["movieId"].As<string>();
                var movieTitle = record["movieTitle"].As<string>();

                nodes.TryAdd(
                    movieIdValue,
                    new MovieRelationshipNodeDto
                    {
                        Id = movieIdValue,
                        Label = movieTitle,
                        Type = "Movie"
                    });

                var relatedIdValue = record["relatedId"].As<string?>();

                if (string.IsNullOrWhiteSpace(relatedIdValue))
                {
                    continue;
                }

                var relatedNameValue =
                    record["relatedName"].As<string?>()
                    ?? relatedIdValue;

                var relatedLabels =
                    record["relatedLabels"].As<List<string>>();

                var relatedType =
                    relatedLabels.FirstOrDefault()
                    ?? "Unknown";

                nodes.TryAdd(
                    relatedIdValue,
                    new MovieRelationshipNodeDto
                    {
                        Id = relatedIdValue,
                        Label = relatedNameValue,
                        Type = relatedType
                    });
            }

            var relationships = result.Result
                .Where(record =>
                    !string.IsNullOrWhiteSpace(
                        record["relatedId"].As<string?>()))
                .Select(record => new MovieRelationshipDto
                {
                    Source = record["movieId"].As<string>(),
                    Target = record["relatedId"].As<string>(),
                    Type = record["relationshipType"].As<string>()
                })
                .ToList();

            return new MovieRelationshipGraphDto
            {
                Nodes = nodes.Values.ToList(),
                Relationships = relationships
            };
        }
    }
}
