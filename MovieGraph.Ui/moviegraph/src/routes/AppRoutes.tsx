import { BrowserRouter, Routes, Route } from "react-router-dom";
import Movies from "../pages/Movies/Movies";
import MovieDetails from "../pages/MovieDetails/MovieDetails";
import Navbar from "../components/common/Navbar";
import Recommendations from "../pages/Recommendations/Recommendations";
import Home from "../pages/Home/Home";

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/movies" element={<Movies />} />
        <Route path="/movies/:movieId" element={<MovieDetails />} />
        <Route path="/recommendations" element={<Recommendations />} />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;