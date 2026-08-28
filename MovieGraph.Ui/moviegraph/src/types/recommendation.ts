import type { Movie } from "./movie";

export interface Recommendation extends Movie {
  score?: number;
}