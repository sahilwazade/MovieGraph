using Neo4j.Driver;

namespace MovieGraph.Infrastructure.Persistence
{
    public sealed class CognoDbConnection
    {
        public IDriver Driver { get; }

        public CognoDbConnection(CognoDbOptions options)
        {
            Driver = GraphDatabase.Driver(options.Uri, AuthTokens.Basic(options.Username, options.Password));
        }

        public async ValueTask DisposeAsync()
        {
            await Driver.DisposeAsync();
        }
    }
}
