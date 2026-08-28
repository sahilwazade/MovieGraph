using MovieGraph.Application.DTOs;
using MovieGraph.Application.Exceptions;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Application.Interfaces.Services;
using MovieGraph.Domain.Entities;

namespace MovieGraph.Application.Services
{
    public sealed class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IReadOnlyList<MovieDto>> GetAllMovies(CancellationToken cancellationToken = default)
        {
            var movies = await _movieRepository.GetAllMovies(cancellationToken);
            return movies
                .Select(MapToDto)
                .ToList();
        }

        public async Task<MovieDto> GetMovieById(string movieId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(movieId))
            {
                throw new BadRequestException("MovieId is required.");
            }

            var movie = await _movieRepository.GetMovieById(movieId, cancellationToken);
            if (movie is null)
            {
                throw new NotFoundException($"Movie with id '{movieId}' was not found.");
            }

            return MapToDto(movie);
        }

        public async Task<IReadOnlyList<MovieDto>> GetSimilarMovies(string movieId, CancellationToken cancellationToken = default)
        {
            var movies = await _movieRepository.GetSimilarMovies(movieId, cancellationToken);

            if (movies is null)
            {
                throw new NotFoundException($"Movies with id '{movieId}' was not found.");
            }

            return movies.Select(MapToDto).ToList();
        }

        public async Task<MovieDto> CreateMovie(MovieDto movie, CancellationToken cancellationToken = default)
        {
            if (movie is null)
            {
                throw new BadRequestException("Movie data is required.");
            }

            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new BadRequestException("Movie title is required.");
            }

            if (movie.ReleaseYear <= 0)
            {
                throw new BadRequestException("Release year must be greater than 0.");
            }

            if (movie.Rating < 0 || movie.Rating > 10)
            {
                throw new BadRequestException("Rating must be between 0 and 10.");
            }


            var entity = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl
            };

            var createdMovie = await _movieRepository.CreateMovie(entity, cancellationToken);
            return MapToDto(createdMovie);
        }

        private static MovieDto MapToDto(Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl
            };
        }
    }
}
