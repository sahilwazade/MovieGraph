namespace MovieGraph.Infrastructure.Queries
{
    public class MovieQueries
    {
        public const string GetAll = """
        MATCH (m:Movie)
        RETURN
            m.id AS id,
            m.title AS title,
            m.releaseYear AS releaseYear,
            m.rating AS rating,
            m.description AS description,
            m.posterUrl AS posterUrl
        ORDER BY m.title
        """;

        public const string GetById = """
        MATCH (m:Movie {id: $movieId})
        RETURN
            m.id AS id,
            m.title AS title,
            m.releaseYear AS releaseYear,
            m.rating AS rating,
            m.description AS description,
            m.posterUrl AS posterUrl
        """;

        public const string Create = """
        CREATE (m:Movie {
            id: $id,
            title: $title,
            releaseYear: $releaseYear,
            rating: $rating,
            description: $description,
            posterUrl: $posterUrl
        })
        RETURN
            m.id AS id,
            m.title AS title,
            m.releaseYear AS releaseYear,
            m.rating AS rating,
            m.description AS description,
            m.posterUrl AS posterUrl
        """;

        public const string GetSimilarMovies = """
        MATCH (source:Movie {id: $movieId})
              -[:ACTED_BY]->(actor:Actor)
              <-[:ACTED_BY]-(similar:Movie)
        WHERE similar.id <> $movieId
        RETURN DISTINCT
            similar.id AS id,
            similar.title AS title,
            similar.releaseYear AS releaseYear,
            similar.rating AS rating,
            similar.description AS description,
            similar.posterUrl AS posterUrl
        ORDER BY similar.rating DESC
        """;

    }
}
