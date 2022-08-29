using System.Net;
using GoodRead.Utilities.Exceptions;
using Newtonsoft.Json;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

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
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Request.ContentType = "application/json";
        var result = string.Empty;

        switch (exception)
        {
            case BadRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = exception.Message;
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;

            case ValidationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                //result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(new { error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}