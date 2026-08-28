namespace MovieGraph.Application.DTOs
{
    public sealed class MovieDto
    {
        public string Id { get; init; } = string.Empty;

        public string Title { get; init; } = string.Empty;

        public int ReleaseYear { get; init; }

        public double Rating { get; init; }

        public string Description { get; init; } = string.Empty;
        public string? PosterUrl { get; init; } = string.Empty;

    }
}
