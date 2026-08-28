namespace MovieGraph.Infrastructure.Persistence
{
    public sealed class CognoDbOptions
    {
        public string Uri { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
