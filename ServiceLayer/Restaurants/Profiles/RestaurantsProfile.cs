using AutoMapper;
using Domain.Layer;
using Domain.Layer.Entities;
using Service.Layer.DTOs.Restaurants;
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
            CreateMap<Restaurant, RestaurantDto>()
                // Map Address properties to Street and Zipcode
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                // Map List<Dish> to List<DishVM>
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

            // Map RestaurantVM to Restaurant
            CreateMap<RestaurantDto, Restaurant>()
                // Map Street and Zipcode back to an Address object
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    ZipCode = src.ZipCode,
                    City = src.City,
                    State = src.State
                }))
                // Map List<DishVM> to List<Dish>
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

            // Map Dish to DishVM (for the Dishes collection)
            CreateMap<Dish, DishDto>().ReverseMap();

            // Map the Create models to the Restaurant entity
            CreateMap<Restaurant, CreateRestaurantDto>().ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes)).ReverseMap();


        }
    }
}
