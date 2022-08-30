using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Context;
using GoodRead.Domain.Repositories.Implements;
using GoodRead.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodRead.Domain
{
    public  static  class DomainRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(configs =>
            {
                //configs.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                configs.UseInMemoryDatabase("GoodReadDb");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
