using Domain.Layer;
using Domain.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Contexts
{
    public class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }

}
