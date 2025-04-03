﻿using Data.Layer.Contexts;
using Microsoft.EntityFrameworkCore;
using Repository.Layer;
using Repository.Layer.Interfaces;
using Service.Layer.Restaurants;
using System;

namespace Restaurant_WebApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RestaurantDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork<RestaurantDBContext>), typeof(UnitOfWork<RestaurantDBContext>));

            services.AddScoped<IRestaurantService, RestaurantService>();

            return services;
        }
    }
}
