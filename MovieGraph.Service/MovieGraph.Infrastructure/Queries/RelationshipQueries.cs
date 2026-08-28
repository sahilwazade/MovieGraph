namespace MovieGraph.Infrastructure.Queries
{
    public static class RelationshipQueries
    {
        public const string AddActorToMovie = """
        MATCH (m:Movie {id: $movieId})
        MATCH (a:Actor {id: $actorId})
        MERGE (m)-[:ACTED_BY]->(a)
        """;

        public const string AddDirectorToMovie = """
        MATCH (m:Movie {id: $movieId})
        MATCH (d:Director {id: $directorId})
        MERGE (m)-[:DIRECTED_BY]->(d)
        """;

        public const string AddGenreToMovie = """
        MATCH (m:Movie {id: $movieId})
        MATCH (g:Genre {id: $genreId})
        MERGE (m)-[:HAS_GENRE]->(g)
        """;

        public const string AddMovieToUser = """
        MATCH (u:User {id: $userId})
        MATCH (m:Movie {id: $movieId})
        MERGE (u)-[:WATCHED]->(m)
        """;

        public const string GetMovieRelationships = """
            MATCH (movie:Movie {id: $movieId})
            OPTIONAL MATCH (movie)-[r]-(related)

            RETURN
                movie.id AS movieId,
                movie.title AS movieTitle,
                type(r) AS relationshipType,
                CASE
                    WHEN related IS NULL THEN NULL
                    ELSE related.id
                END AS relatedId,
                CASE
                    WHEN related IS NULL THEN NULL
                    ELSE COALESCE(related.title, related.name)
                END AS relatedName,
                CASE
                    WHEN related IS NULL THEN []
                    ELSE labels(related)
                END AS relatedLabels
            """;
    }
}
