namespace MovieGraph.Application.DTOs
{
    public sealed class RecommendationDto
    {
        public string MovieId { get; init; } = string.Empty;

        public string Title { get; init; } = string.Empty;

        public double Rating { get; init; }

        public string Reason { get; init; } = string.Empty;

    }
}
