import { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import MovieCard from "../../components/movies/MovieCard";
import { getAllMovies } from "../../services/movieService";

type SortOption = "rating" | "year" | "title";

const Movies = () => {
  const [search, setSearch] = useState("");
  const [sortBy, setSortBy] = useState<SortOption>("rating");

  const {
    data: movies = [],
    isLoading,
    isError,
    refetch,
  } = useQuery({
    queryKey: ["movies"],
    queryFn: getAllMovies,
  });

  const filteredMovies = useMemo(() => {
    const result = movies.filter((movie) =>
      movie.title.toLowerCase().includes(search.toLowerCase())
    );

    return [...result].sort((a, b) => {
      switch (sortBy) {
        case "rating":
          return b.rating - a.rating;

        case "year":
          return b.releaseYear - a.releaseYear;

        case "title":
          return a.title.localeCompare(b.title);

        default:
          return 0;
      }
    });
  }, [movies, search, sortBy]);

  if (isLoading) {
    return (
      <main className="min-h-screen bg-gray-950 px-6 py-10 text-white">
        <div className="mx-auto max-w-7xl">
          <h1 className="text-3xl font-bold">Movies</h1>

          <div className="mt-8 grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5">
            {Array.from({ length: 10 }).map((_, index) => (
              <div
                key={index}
                className="h-96 animate-pulse rounded-xl bg-gray-900"
              />
            ))}
          </div>
        </div>
      </main>
    );
  }

  if (isError) {
    return (
      <main className="flex min-h-screen items-center justify-center bg-gray-950 px-6 text-white">
        <div className="text-center">
          <h1 className="text-2xl font-bold">
            Unable to load movies
          </h1>

          <p className="mt-2 text-gray-400">
            Something went wrong while fetching movies.
          </p>

          <button
            onClick={() => refetch()}
            className="mt-6 rounded-lg bg-white px-5 py-2.5 font-medium text-black hover:bg-gray-200"
          >
            Try Again
          </button>
        </div>
      </main>
    );
  }

  return (
    <main className="min-h-screen bg-gray-950 px-6 py-10 text-white">
      <div className="mx-auto max-w-7xl">
        {/* Header */}
        <div className="flex flex-col gap-2">
          <h1 className="text-3xl font-bold">
            Movies
          </h1>

          <p className="text-gray-400">
            Explore our movie collection.
          </p>
        </div>

        {/* Search + Sort */}
        <div className="mt-8 flex flex-col gap-4 sm:flex-row">
          <input
            type="text"
            placeholder="Search movies..."
            value={search}
            onChange={(event) => setSearch(event.target.value)}
            className="w-full rounded-lg border border-gray-800 bg-gray-900 px-4 py-3 text-white outline-none placeholder:text-gray-500 focus:border-gray-600 sm:max-w-md"
          />

          <select
            value={sortBy}
            onChange={(event) =>
              setSortBy(event.target.value as SortOption)
            }
            className="rounded-lg border border-gray-800 bg-gray-900 px-4 py-3 text-white outline-none"
          >
            <option value="rating">
              Sort by Rating
            </option>

            <option value="year">
              Sort by Release Year
            </option>

            <option value="title">
              Sort by Title
            </option>
          </select>
        </div>

        {/* Results */}
        {filteredMovies.length === 0 ? (
          <div className="mt-16 text-center">
            <div className="text-5xl">🎬</div>

            <h2 className="mt-4 text-xl font-semibold">
              No movies found
            </h2>

            <p className="mt-2 text-gray-400">
              Try searching with a different movie title.
            </p>
          </div>
        ) : (
          <>
            <p className="mt-8 text-sm text-gray-500">
              {filteredMovies.length} movies
            </p>

            <div className="mt-4 grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5">
              {filteredMovies.map((movie) => (
                <MovieCard
                  key={movie.id}
                  movie={movie}
                />
              ))}
            </div>
          </>
        )}
      </div>
    </main>
  );
};

export default Movies;