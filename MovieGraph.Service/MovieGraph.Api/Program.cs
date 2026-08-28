using MovieGraph.Api.Middleware;
using MovieGraph.Application.Extensions;
using MovieGraph.Infrastructure.Extensions;
using MovieGraph.Infrastructure.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MovieGraph API",
        Version = "v1",
        Description = "Movie recommendation API powered by CognoDB."
    });
}); 
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services
    .AddHealthChecks()
    .AddCheck<CognoDbHealthCheck>("cognodb");

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        policy
            .WithOrigins("https://movie-graph-89bt1k2q9-sahils-projects-65eeb38e.vercel.app",
                         "https://movie-graph-f93fpphtp-sahils-projects-65eeb38e.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ReactClient");
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
