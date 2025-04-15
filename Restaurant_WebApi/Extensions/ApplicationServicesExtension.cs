using Data.Layer.Contexts;
using Microsoft.EntityFrameworkCore;
using Repository.Layer;
using Repository.Layer.Interfaces;
using Service.Layer.Commands;
using Service.Layer.Queries;
using Service.Layer.Restaurants;
using Service.Layer.Restaurants.Profiles;
using System;
using System.Reflection;

namespace Restaurant_WebApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RestaurantDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork<RestaurantDBContext>), typeof(UnitOfWork<RestaurantDBContext>));

            services.AddScoped<ExceptionMiddleware>(); // Add the exception middleware>

            // Dynamically load assemblies containing handlers
            var assemblies = new[]
            {
                Assembly.Load("Service.Layer"),                          // Replace with your actual project names
            };

            // Register all MediatR handlers from these assemblies
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

            // Register the auto mapper
            services.AddAutoMapper(typeof(RestaurantsProfile));

            return services;
        }
    }
}
