using Data.Layer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Restaurant_WebApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RestaurantDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
