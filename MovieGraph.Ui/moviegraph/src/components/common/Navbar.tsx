import { NavLink } from "react-router-dom";

const Navbar = () => {
  const getNavClass = ({ isActive }: { isActive: boolean }) =>
    `transition ${
      isActive
        ? "text-white"
        : "text-gray-400 hover:text-white"
    }`;

  return (
    <header className="border-b border-gray-800 bg-gray-950">
      <nav className="mx-auto flex max-w-7xl items-center justify-between px-6 py-4">
        {/* Logo */}
        <NavLink
          to="/"
          className="text-xl font-bold tracking-tight text-white"
        >
          🎬 MovieGraph
        </NavLink>

        {/* Navigation */}
        <div className="flex items-center gap-6 text-sm font-medium">
          <NavLink
            to="/"
            className={getNavClass}
          >
            Home
          </NavLink>

          <NavLink
            to="/movies"
            className={getNavClass}
          >
            Movies
          </NavLink>

          <NavLink
            to="/recommendations"
            className={getNavClass}
          >
            Recommendations
          </NavLink>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;