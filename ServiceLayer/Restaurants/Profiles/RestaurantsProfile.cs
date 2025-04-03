using AutoMapper;
using Domain.Layer;
using Domain.Layer.Entities;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Restaurants.Profiles
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            // Map Restaurant to RestaurantVM
            CreateMap<Restaurant, RestaurantVM>()
                // Map Address properties to Street and Zipcode
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                // Map List<Dish> to List<DishVM>
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

            // Map RestaurantVM to Restaurant
            CreateMap<RestaurantVM, Restaurant>()
                // Map Street and Zipcode back to an Address object
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    ZipCode = src.Zipcode,
                    City = src.City,
                    State = src.State
                }))
                // Map List<DishVM> to List<Dish>
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

            // Map Dish to DishVM (for the Dishes collection)
            CreateMap<Dish, DishVM>();

            // Map DishVM to Dish (for the reverse mapping)
            CreateMap<DishVM, Dish>()
                // RestaurantId might need to be set elsewhere (e.g., in the service layer)
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore());
        }
    }
}
