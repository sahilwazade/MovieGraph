import apiClient from "./apiClient";
import type {MovieRelationshipGraph} from "../types/relationship";

export const getMovieRelationships = async (
  movieId: string
): Promise<MovieRelationshipGraph> => {
  const response = await apiClient.get<MovieRelationshipGraph>(
    `/Movies/${movieId}/relationships`
  );

  return response.data;
};