import { useQuery } from "@tanstack/react-query";
import { useParams, Link } from "react-router-dom";
import { getMovieById, getSimilarMovies } from "../../services/movieService";

import MovieCard from "../../components/movies/MovieCard";
import MovieRelationshipGraph from "../../components/relationships/MovieRelationshipGraph";

const MovieDetails = () => {
  const { movieId } = useParams<{ movieId: string }>();

  const {
    data: movie,
    isLoading,
    isError,
  } = useQuery({
    queryKey: ["movie", movieId],
    queryFn: () => getMovieById(movieId!),
    enabled: Boolean(movieId),
  });

  const { data: similarMovies = [], isLoading: isSimilarLoading } = useQuery({
    queryKey: ["similar-movies", movieId],
    queryFn: () => getSimilarMovies(movieId!),
    enabled: Boolean(movieId),
  });

  // Loading
  if (isLoading) {
    return (
      <div className="flex min-h-screen items-center justify-center bg-gray-950 text-white">
        Loading movie...
      </div>
    );
  }

  // Error
  if (isError || !movie) {
    return (
      <div className="flex min-h-screen flex-col items-center justify-center gap-4 bg-gray-950 text-white">
        <h1 className="text-2xl font-bold">Movie not found</h1>

        <Link to="/movies" className="rounded-lg bg-white px-5 py-2 text-black">
          Back to Movies
        </Link>
      </div>
    );
  }

  return (
    <main className="min-h-screen bg-gray-950 px-6 py-10 text-white">
      <div className="mx-auto max-w-7xl">
        {/* Back */}
        <Link
          to="/movies"
          className="inline-flex items-center gap-2 text-sm text-gray-400 transition hover:text-white"
        >
          ← Back to Movies
        </Link>

        {/* ================================================= */}
        {/* MOVIE DETAILS */}
        {/* ================================================= */}

        <section className="relative mt-8 h-162.5 overflow-hidden rounded-2xl border border-gray-800">
          {/* ============================================== */}
          {/* Poster Background */}
          {/* ============================================== */}

          {movie.posterUrl ? (
            <div className="absolute inset-0">
              {/* Blurred Background */}
              <img
                src={movie.posterUrl}
                alt=""
                className="absolute inset-0 h-full w-full scale-110 object-cover opacity-40 blur-2xl"
              />

              {/* Full Poster */}
              <img
                src={movie.posterUrl}
                alt={`${movie.title} poster`}
                className="absolute inset-0 h-full w-full object-contain"
              />
            </div>
          ) : (
            <div className="absolute inset-0 flex items-center justify-center bg-gray-900 text-gray-600">
              No Poster
            </div>
          )}

          <div className="absolute inset-0 bg-linear-to-t from-gray-950 via-gray-950/60 to-transparent" />

          <div className="relative z-10 flex h-full items-end px-8 py-12">
            <div className="max-w-2xl">
              <p className="text-sm font-medium uppercase tracking-wider text-gray-300">
                Movie
              </p>

              <h1 className="mt-3 text-5xl font-bold tracking-tight text-white">
                {movie.title}
              </h1>

              {/* Year + Rating */}
              <div className="mt-6 flex flex-wrap gap-3">
                <span className="rounded-full bg-black/60 px-4 py-2 text-sm text-gray-200 backdrop-blur">
                  {movie.releaseYear}
                </span>

                <span className="rounded-full bg-black/60 px-4 py-2 text-sm text-gray-200 backdrop-blur">
                  ⭐ {movie.rating}
                </span>
              </div>

              {/* Description */}
              <p className="mt-8 text-lg leading-8 text-gray-300">
                {movie.description}
              </p>
            </div>
          </div>
        </section>

        {/* ================================================= */}
        {/* RELATIONSHIP GRAPH */}
        {/* ================================================= */}

        <section className="mt-16">
          <h2 className="text-2xl font-bold">Movie Relationships</h2>

          <p className="mt-2 text-gray-400">
            Explore the connections between this movie, genres, actors,
            directors and users.
          </p>

          <div className="mt-6 h-162.5 w-full">
            <MovieRelationshipGraph movieId={movie.id} />
          </div>
        </section>

        {/* ================================================= */}
        {/* SIMILAR MOVIES */}
        {/* ================================================= */}

        <section className="mt-16 border-t border-gray-800 pt-10">
          <h2 className="text-2xl font-bold">Similar Movies</h2>

          <p className="mt-2 text-gray-400">
            Movies that share similar genres and relationships.
          </p>

          {/* Loading */}
          {isSimilarLoading && (
            <div className="mt-8 grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5">
              {Array.from({ length: 5 }).map((_, index) => (
                <div
                  key={index}
                  className="h-96 animate-pulse rounded-xl bg-gray-900"
                />
              ))}
            </div>
          )}

          {/* Empty */}
          {!isSimilarLoading && similarMovies.length === 0 && (
            <div className="mt-10 rounded-xl border border-gray-800 bg-gray-900/50 p-10 text-center">
              <div className="text-4xl">🎬</div>

              <p className="mt-3 text-gray-400">No similar movies found.</p>
            </div>
          )}

          {/* Similar Movies */}
          {!isSimilarLoading && similarMovies.length > 0 && (
            <div className="mt-8 grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5">
              {similarMovies.map((similarMovie) => (
                <MovieCard key={similarMovie.id} movie={similarMovie} />
              ))}
            </div>
          )}
        </section>
      </div>
    </main>
  );
};

export default MovieDetails;
