import apiClient from "./apiClient";
import type { Recommendation } from "../types/recommendation";

export const getRecommendations = async (
  userId: string,
  limit = 10
): Promise<Recommendation[]> => {
  const response = await apiClient.get<Recommendation[]>(
    `/Recommendation/${userId}`,
    {
      params: {
        limit,
      },
    }
  );

  return response.data;
};