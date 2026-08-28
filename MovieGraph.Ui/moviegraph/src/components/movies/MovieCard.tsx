import { Link } from "react-router-dom";
import type { Movie } from "../../types/movie";

interface MovieCardProps {
  movie: Movie;
}

const MovieCard = ({ movie }: MovieCardProps) => {
  return (
    <Link to={`/movies/${movie.id}`}>
      <div className="overflow-hidden rounded-xl bg-gray-900 transition hover:-translate-y-1 hover:shadow-xl">
        {movie.posterUrl ? (
          <img
            src={movie.posterUrl}
            alt={movie.title}
            className="h-72 w-full object-cover"
          />
        ) : (
          <div className="flex h-72 w-full items-center justify-center bg-gray-800 text-gray-500">
            No Poster
          </div>
        )}

        <div className="p-4">
          <h2 className="truncate text-lg font-semibold">
            {movie.title}
          </h2>

          <p className="mt-1 text-sm text-gray-400">
            {movie.releaseYear}
          </p>

          <p className="mt-2 text-sm">
            ⭐ {movie.rating.toFixed(1)}
          </p>
        </div>
      </div>
    </Link>
  );
};

export default MovieCard;