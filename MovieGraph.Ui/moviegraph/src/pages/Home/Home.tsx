import { Link } from "react-router-dom";

const Home = () => {
  return (
    <main className="min-h-screen bg-gray-950 text-white">
      {/* Hero */}
      <section className="mx-auto flex min-h-[70vh] max-w-7xl items-center px-6 py-20">
        <div className="max-w-3xl">
          <p className="mb-4 text-sm font-semibold uppercase tracking-widest text-gray-400">
            MovieGraph
          </p>

          <h1 className="text-5xl font-bold tracking-tight sm:text-6xl">
            Discover movies
            <span className="block text-gray-400">
              you'll love.
            </span>
          </h1>

          <p className="mt-6 max-w-2xl text-lg leading-8 text-gray-400">
            Explore movies, discover similar titles, and get
            personalized recommendations based on your watch history.
          </p>

          <div className="mt-8 flex gap-4">
            <Link
              to="/movies"
              className="rounded-lg bg-white px-6 py-3 font-semibold text-black transition hover:bg-gray-200"
            >
              Explore Movies
            </Link>

            <Link
              to="/recommendations"
              className="rounded-lg border border-gray-700 px-6 py-3 font-semibold text-white transition hover:bg-gray-900"
            >
              Recommendations
            </Link>
          </div>
        </div>
      </section>

      {/* Features */}
      <section className="border-t border-gray-800">
        <div className="mx-auto grid max-w-7xl gap-6 px-6 py-16 md:grid-cols-3">
          <div className="rounded-xl border border-gray-800 bg-gray-900 p-6">
            <h2 className="text-lg font-semibold">
              Explore Movies
            </h2>

            <p className="mt-2 text-sm leading-6 text-gray-400">
              Browse the movie collection and discover highly rated
              titles.
            </p>
          </div>

          <div className="rounded-xl border border-gray-800 bg-gray-900 p-6">
            <h2 className="text-lg font-semibold">
              Smart Recommendations
            </h2>

            <p className="mt-2 text-sm leading-6 text-gray-400">
              Get recommendations based on relationships between
              movies and genres.
            </p>
          </div>

          <div className="rounded-xl border border-gray-800 bg-gray-900 p-6">
            <h2 className="text-lg font-semibold">
              Graph Powered
            </h2>

            <p className="mt-2 text-sm leading-6 text-gray-400">
              Discover connections that are naturally represented
              using a graph database.
            </p>
          </div>
        </div>
      </section>
    </main>
  );
};

export default Home;