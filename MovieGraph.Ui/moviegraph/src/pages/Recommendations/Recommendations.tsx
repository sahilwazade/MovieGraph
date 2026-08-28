import { useQuery } from "@tanstack/react-query";
import { getRecommendations } from "../../services/recommendationService";
import MovieCard from "../../components/movies/MovieCard";

const USER_ID = "user-1";

const Recommendations = () => {
  const {
    data: recommendations = [],
    isLoading,
    isError,
    refetch,
  } = useQuery({
    queryKey: ["recommendations", USER_ID],
    queryFn: () => getRecommendations(USER_ID, 10),
  });

  if (isLoading) {
    return (
      <main className="min-h-screen bg-gray-950 px-6 py-10 text-white">
        <div className="mx-auto max-w-7xl">
          <div className="h-9 w-72 animate-pulse rounded bg-gray-800" />

          <div className="mt-3 h-5 w-96 animate-pulse rounded bg-gray-900" />

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
          <div className="text-5xl">⚠️</div>

          <h1 className="mt-4 text-2xl font-bold">
            Unable to load recommendations
          </h1>

          <p className="mt-2 text-gray-400">
            Something went wrong while fetching your recommendations.
          </p>

          <button
            onClick={() => refetch()}
            className="mt-6 rounded-lg bg-white px-5 py-2.5 font-medium text-black transition hover:bg-gray-200"
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
        <div>
          <h1 className="text-3xl font-bold">
            Recommended For You
          </h1>

          <p className="mt-2 text-gray-400">
            Movies selected based on your watching history and
            similar genres.
          </p>
        </div>

        {/* Empty State */}
        {recommendations.length === 0 ? (
          <div className="mt-20 text-center">
            <div className="text-5xl">🎬</div>

            <h2 className="mt-4 text-xl font-semibold">
              No recommendations yet
            </h2>

            <p className="mt-2 text-gray-400">
              Watch some movies to get personalized recommendations.
            </p>
          </div>
        ) : (
          <>
            <div className="mt-8">
              <p className="text-sm text-gray-500">
                {recommendations.length} recommendations
              </p>
            </div>

            {/* Recommendation Grid */}
            <div className="mt-4 grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5">
              {recommendations.map((movie) => (
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

export default Recommendations;