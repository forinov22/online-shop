using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException e)
        {
            await SendError(context, e);
        }
        catch (AlreadyExistsException e)
        {
            await SendError(context, e);
        }
        catch (AuthorizationException e)
        {
            await SendError(context, e);
        }
        catch (InvalidOperationException e)
        {
            await SendError(context, e);
        }
    }

    private async Task SendError(HttpContext context, Exception e)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;    
        context.Response.ContentType = "application/json";

        ProblemDetails problem = new()
        {
            Status = (int)HttpStatusCode.BadRequest,
            Detail = e.Message
        };

        var json = JsonSerializer.Serialize(problem);
        await context.Response.WriteAsJsonAsync(json);
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
