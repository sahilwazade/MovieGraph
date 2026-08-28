namespace MovieGraph.Infrastructure.Queries
{
    public static class MovieRecomendationQueries
    {
        //public const string RecomendationQuery = """
        //MATCH (u:User {id: $userId})
        //      -[:WATCHED]->
        //      (watched:Movie)

        //WITH u, collect(DISTINCT watched.id) AS watchedMovieIds

        //MATCH (u)-[:WATCHED]->(watchedMovie:Movie)
        //      -[:HAS_GENRE]->(genre:Genre)
        //      <-[:HAS_GENRE]-(recommended:Movie)

        //WHERE NOT recommended.id IN watchedMovieIds

        //WITH recommended, count(DISTINCT genre) AS score

        //RETURN
        //    recommended.id AS id,
        //    recommended.title AS title,
        //    recommended.releaseYear AS releaseYear,
        //    recommended.rating AS rating,
        //    recommended.description AS description,
        //    score

        //ORDER BY score DESC, recommended.rating DESC
        //""";

        public const string RecomendationQuery = """
        MATCH (u:User {id: $userId})
              -[:WATCHED]->
              (watched:Movie)

        WITH u, collect(DISTINCT watched.id) AS watchedMovieIds

        MATCH (u)-[:WATCHED]->(watchedMovie:Movie)
              -[:HAS_GENRE]->(genre:Genre)
              <-[:HAS_GENRE]-(recommended:Movie)

        WHERE NOT recommended.id IN watchedMovieIds

        WITH recommended, count(DISTINCT genre) AS score

        RETURN
            recommended.id AS id,
            recommended.title AS title,
            recommended.releaseYear AS releaseYear,
            recommended.rating AS rating,
            recommended.description AS description,
            recommended.posterUrl AS posterUrl,
            score

        ORDER BY score DESC, recommended.rating DESC
        """;
    }
}
