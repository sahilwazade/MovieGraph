using MovieGraph.Application.DTOs;
using MovieGraph.Application.Exceptions;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Application.Interfaces.Services;

namespace MovieGraph.Application.Services
{
    public sealed class MovieRelationshipService : IMovieRelationshipService
    {
        private readonly IMovieRelationshipRepository _repository;
        public MovieRelationshipService(
            IMovieRelationshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieRelationshipGraphDto> GetMovieRelationships(string movieId,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(movieId))
            {
                throw new BadRequestException(
                    "MovieId is required.");
            }

            return await _repository.GetMovieRelationships(movieId, cancellationToken);
        }
    }
}
