using Microsoft.Extensions.DependencyInjection;
using MovieGraph.Application.Interfaces.Services;
using MovieGraph.Application.Services;

namespace MovieGraph.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<IMovieRelationshipService, MovieRelationshipService>();
            return services;
        }
    }
}
