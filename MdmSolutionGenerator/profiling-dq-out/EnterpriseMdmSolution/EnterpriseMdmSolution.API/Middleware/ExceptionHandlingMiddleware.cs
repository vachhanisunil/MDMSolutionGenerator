using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMdmSolution.API.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            await WriteProblemAsync(context, StatusCodes.Status400BadRequest, "Validation failed", exception.Errors.Select(e => e.ErrorMessage));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled API exception");
            await WriteProblemAsync(context, StatusCodes.Status500InternalServerError, "Unexpected error", ["An unexpected error occurred."]);
        }
    }

    private static async Task WriteProblemAsync(HttpContext context, int status, string title, IEnumerable<string> errors)
    {
        context.Response.StatusCode = status;
        var problem = new ValidationProblemDetails(errors.GroupBy(_ => "Errors").ToDictionary(g => g.Key, g => g.ToArray()))
        {
            Status = status,
            Title = title
        };

        await context.Response.WriteAsJsonAsync(problem);
    }
}