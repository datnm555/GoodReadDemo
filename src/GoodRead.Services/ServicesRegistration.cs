using System.Reflection;

namespace GoodRead.Services;

public static class ServicesRegistration
{
    public static IServiceCollection AddServiceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}
