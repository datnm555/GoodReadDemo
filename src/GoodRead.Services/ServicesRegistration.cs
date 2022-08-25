namespace GoodRead.Services;

public static class ServicesRegistration
{
    public static IServiceCollection AddServiceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}
