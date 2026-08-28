using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Seed
{
    public sealed class DatabaseSeeder
    {
        private readonly IDriver _driver;

        public DatabaseSeeder(IDriver driver)
        {
            _driver = driver;
        }

        public async Task SeedAsync(
            CancellationToken cancellationToken = default)
        {
            await using var session = _driver.AsyncSession();

            await session.ExecuteWriteAsync(
                async transaction =>
                {
                    foreach (var statement in SeedData.SeedStatements)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        await transaction.RunAsync(statement);
                    }

                    return true;
                });
        }
    }
}
