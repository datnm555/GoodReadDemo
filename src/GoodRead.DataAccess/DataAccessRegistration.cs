namespace GoodRead.DataAccess;

public static class DataAccessRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GoodReadDbContext>(cfs =>
        {
            cfs.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}