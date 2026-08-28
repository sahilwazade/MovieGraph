using Microsoft.Extensions.Diagnostics.HealthChecks;
using Neo4j.Driver;

namespace MovieGraph.Infrastructure.HealthChecks
{
    public sealed class CognoDbHealthCheck: IHealthCheck
    {
        private readonly IDriver _driver;

        public CognoDbHealthCheck(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _driver
                    .ExecutableQuery("RETURN 1 AS result")
                    .ExecuteAsync(cancellationToken);

                return HealthCheckResult.Healthy("CognoDB is reachable.");
            }
            catch (Exception exception)
            {
                return HealthCheckResult.Unhealthy("CognoDB is unavailable.", exception);
            }
        }

    }
}
