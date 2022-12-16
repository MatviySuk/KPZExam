using System.Net;

namespace KPZExamServer;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    public ExceptionHandler(RequestDelegate next)
    { 
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        { 
            await _next(httpContext);
        }
        catch (Exception ex)
        { 
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    { 
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        if (exception is ArgumentException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }

        await context.Response.WriteAsync(exception.Message);
    }
}