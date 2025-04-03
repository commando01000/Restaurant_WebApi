using Data.Layer.Contexts;
using Domain.Layer;
using Domain.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer
{
    public class RestaurantContextSeed
    {
        public RestaurantContextSeed()
        {

        }
        public static async Task Seed(RestaurantDBContext context, ILoggerFactory loggerFactory)
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!await context.Restaurants.AnyAsync())
                {
                    try
                    {
                        var restaurants = GetRestaurants().ToList();
                        await context.Restaurants.AddRangeAsync(restaurants);
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logger = loggerFactory.CreateLogger<RestaurantContextSeed>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
            }
        }

        private static IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
    {
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Pasta Palace",
            Description = "Authentic Italian cuisine",
            Address = new Address
            {
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = 10001
            },
            HasDelivery = true,
            PhoneNumber = "555-0123",
            Email = "info@pastapalace.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Spaghetti Carbonara",
                    Description = "Classic Roman pasta dish",
                    Price = 15.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Margherita Pizza",
                    Description = "Fresh tomato and basil",
                    Price = 12.99m
                }
            }
        },
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Sushi Haven",
            Description = "Fresh Japanese seafood",
            Address = new Address
            {
                Street = "456 Oak Ave",
                City = "San Francisco",
                State = "CA",
                ZipCode = 94102
            },
            HasDelivery = false,
            PhoneNumber = "555-4567",
            Email = "contact@sushihaven.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "California Roll",
                    Description = "Crab and avocado roll",
                    Price = 8.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Spicy Tuna Roll",
                    Description = "Tuna with spicy mayo",
                    Price = 9.99m
                }
            }
        },
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Burger Bonanza",
            Description = "Gourmet burgers and fries",
            Address = new Address
            {
                Street = "789 Pine Rd",
                City = "Chicago",
                State = "IL",
                ZipCode = 60601
            },
            HasDelivery = true,
            PhoneNumber = "555-7890",
            Email = "hello@burgerbonanza.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Classic Cheeseburger",
                    Description = "Beef patty with cheddar",
                    Price = 10.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Truffle Fries",
                    Description = "Hand-cut fries with truffle oil",
                    Price = 6.99m
                }
            }
        },
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Taco Fiesta",
            Description = "Authentic Mexican flavors",
            Address = new Address
            {
                Street = "321 Fiesta Lane",
                City = "Austin",
                State = "TX",
                ZipCode = 78701
            },
            HasDelivery = true,
            PhoneNumber = "555-2345",
            Email = "hola@tacofiesta.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Carne Asada Tacos",
                    Description = "Grilled steak tacos",
                    Price = 11.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Guacamole & Chips",
                    Description = "Fresh avocado dip",
                    Price = 7.99m
                }
            }
        },
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Curry Corner",
            Description = "Traditional Indian cuisine",
            Address = new Address
            {
                Street = "654 Spice St",
                City = "Seattle",
                State = "WA",
                ZipCode = 98101
            },
            HasDelivery = true,
            PhoneNumber = "555-6789",
            Email = "namaste@currycorner.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Butter Chicken",
                    Description = "Creamy tomato-based curry",
                    Price = 14.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Garlic Naan",
                    Description = "Freshly baked flatbread",
                    Price = 3.99m
                }
            }
        },
        new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Crepe Cafe",
            Description = "Sweet and savory crepes",
            Address = new Address
            {
                Street = "987 Maple Dr",
                City = "Portland",
                State = "OR",
                ZipCode = 97205
            },
            HasDelivery = false,
            PhoneNumber = "555-3456",
            Email = "bonjour@crepecafe.com",
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutella Crepe",
                    Description = "Chocolate hazelnut spread",
                    Price = 8.99m
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham & Cheese Crepe",
                    Description = "Savory crepe with gruyere",
                    Price = 9.99m
                }
            }
        }
    };

            // Set RestaurantId for each dish
            foreach (var restaurant in restaurants)
            {
                foreach (var dish in restaurant.Dishes)
                {
                    dish.RestaurantId = restaurant.Id;
                }
            }

            return restaurants;
        }
    }
}
