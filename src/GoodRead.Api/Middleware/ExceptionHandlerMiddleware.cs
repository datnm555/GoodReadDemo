using GoodRead.Utilities.Responses;

namespace GoodRead.Api.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var errors = new List<string>();

        switch (exception)
        {
            case BadRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                errors.Add(exception.Message);
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case ValidationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                //result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                break;
            default:
                errors.Add(exception.Message);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        var result = JsonConvert.SerializeObject(new ErrorResponse<IActionResult>(false, httpStatusCode, errors));

        return context.Response.WriteAsync(result);
    }
}