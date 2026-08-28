namespace MovieGraph.Domain.Entities
{
    public class Movie
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? PosterUrl { get; set; } = string.Empty;
    }
}
