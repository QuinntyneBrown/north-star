using System.Net;
using System.Text.Json;
using NorthStar.Application.Common.Exceptions;

namespace NorthStar.Api.Middleware;

/// <summary>Translates known application exceptions into clean JSON problem responses.</summary>
public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (ValidationException ex)
        {
            await WriteAsync(context, HttpStatusCode.BadRequest,
                new { title = "Validation failed", status = 400, errors = ex.Errors });
        }
        catch (NotFoundException ex)
        {
            await WriteAsync(context, HttpStatusCode.NotFound,
                new { title = ex.Message, status = 404 });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception processing {Path}", context.Request.Path);
            await WriteAsync(context, HttpStatusCode.InternalServerError,
                new { title = "An unexpected error occurred.", status = 500 });
        }
    }

    private static async Task WriteAsync(HttpContext context, HttpStatusCode status, object payload)
    {
        context.Response.StatusCode = (int)status;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    }
}
