export interface Movie {
  id: string;
  title: string;
  releaseYear: number;
  rating: number;
  description: string;
  posterUrl: string | null;
}