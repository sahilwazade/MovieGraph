namespace MovieGraph.Application.DTOs
{
    public sealed class MovieRelationshipDto
    {
        public string Source { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

    }
}
