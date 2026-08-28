namespace MovieGraph.Application.DTOs
{
    public sealed class MovieRelationshipGraphDto
    {
        public IReadOnlyList<MovieRelationshipNodeDto> Nodes { get; set; }
            = Array.Empty<MovieRelationshipNodeDto>();

        public IReadOnlyList<MovieRelationshipDto> Relationships { get; set; }
            = Array.Empty<MovieRelationshipDto>();

    }
}
