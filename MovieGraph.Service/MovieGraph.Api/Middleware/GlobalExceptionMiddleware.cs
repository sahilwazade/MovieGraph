using MovieGraph.Api.Models;
using MovieGraph.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace MovieGraph.Api.Middleware
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException exception)
            {
                _logger.LogWarning(
                    exception,
                    "Bad request received.");

                await HandleExceptionAsync(
                    context,
                    HttpStatusCode.BadRequest,
                    exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception,
                    "An unhandled exception occurred while processing the request.");

                await HandleExceptionAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
                TraceId = context.TraceIdentifier
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
