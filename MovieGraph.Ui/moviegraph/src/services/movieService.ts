import apiClient from "./apiClient";
import type { Movie } from "../types/movie";

export const getAllMovies = async (): Promise<Movie[]> => {
  const response = await apiClient.get<Movie[]>("/movies/GetMovies");

  return response.data;
};

export const getMovieById = async (
  movieId: string
): Promise<Movie> => {
  const response = await apiClient.get<Movie>(
    `/movies/GetById/${movieId}`
  );

  return response.data;
};

export const getSimilarMovies = async (
  movieId: string
): Promise<Movie[]> => {
  const response = await apiClient.get<Movie[]>(
    `/movies/${movieId}/similar`
  );

  return response.data;
};

export const createMovie = async (
  movie: Movie
): Promise<Movie> => {
  const response = await apiClient.post<Movie>(
    "/movies",
    movie
  );

  return response.data;
};