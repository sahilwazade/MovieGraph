using Microsoft.Extensions.DependencyInjection;
using MovieGraph.Application.Interfaces.Repositories;
using MovieGraph.Infrastructure.Persistence;
using MovieGraph.Infrastructure.Repositories;
using MovieGraph.Infrastructure.Seed;
using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var uri = Environment.GetEnvironmentVariable("COGNODB_URI");
            var username = Environment.GetEnvironmentVariable("COGNODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("COGNODB_PASSWORD");

            if (string.IsNullOrWhiteSpace(uri))
                throw new InvalidOperationException("COGNODB_URI environment variable is not configured.");

            if (string.IsNullOrWhiteSpace(username))
                throw new InvalidOperationException("COGNODB_USERNAME environment variable is not configured.");

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("COGNODB_PASSWORD environment variable is not configured.");

            var options = new CognoDbOptions
            {
                Uri = uri,
                Username = username,
                Password = password
            };

            services.AddSingleton<CognoDbConnection>(_ => new CognoDbConnection(options));
            services.AddSingleton<IDriver>(serviceProvider => serviceProvider.GetRequiredService<CognoDbConnection>().Driver);
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieRelationshipRepository, MovieRelationshipRepository>();
            services.AddScoped<DatabaseSeeder>();
            services.AddScoped<IRecommendationRepository, RecommendationRepository>();

            return services;
        }

    }
}
