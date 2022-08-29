namespace GoodRead.Api.Middleware;

/// <summary>
/// handle extensions
/// </summary>
public static class MiddlewareExtensions
{
    /// <summary>
    /// Init Custom Exception handle
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}