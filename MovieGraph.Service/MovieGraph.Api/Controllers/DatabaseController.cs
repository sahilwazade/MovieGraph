using Microsoft.AspNetCore.Mvc;
using MovieGraph.Infrastructure.Seed;
using Neo4j.Driver;

namespace MovieGraph.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IDriver _driver;
        private readonly DatabaseSeeder _databaseSeeder;
        public DatabaseController(IDriver driver, DatabaseSeeder databaseSeeder)
        {
            _driver = driver;
            _databaseSeeder = databaseSeeder;
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestConnection()
        {
            await _driver.VerifyConnectivityAsync();
            return Ok(new
            {
                message = "Successfully connected to CognoDB."
            });
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabase(
        CancellationToken cancellationToken)
        {
            await _databaseSeeder.SeedAsync(cancellationToken);

            return Ok(new
            {
                message = "Database seeded successfully."
            });
        }
    }
}
