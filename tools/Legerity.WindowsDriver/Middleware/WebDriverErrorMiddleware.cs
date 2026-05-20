namespace Legerity.WindowsDriver.Middleware;

using System.Text.Json;
using Legerity.WindowsDriver.Exceptions;
using Legerity.WindowsDriver.Models;

public class WebDriverErrorMiddleware
{
    private readonly RequestDelegate _next;

    public WebDriverErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (WebDriverException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = "application/json";

            var error = new WebDriverResponse
            {
                Value = new WebDriverError
                {
                    Error = ex.ErrorCode,
                    Message = ex.Message,
                    Stacktrace = ex.StackTrace ?? string.Empty
                }
            };

            await context.Response.WriteAsJsonAsync(error);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var error = new WebDriverResponse
            {
                Value = new WebDriverError
                {
                    Error = WebDriverErrors.UnknownError,
                    Message = ex.Message,
                    Stacktrace = ex.StackTrace ?? string.Empty
                }
            };

            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
