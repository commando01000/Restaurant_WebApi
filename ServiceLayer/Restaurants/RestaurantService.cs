using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using Repository.Layer.Interfaces;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Pagination;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public RestaurantService(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response AddRestaurant(RestaurantVM restaurant)
        {
            throw new NotImplementedException();
        }

        public Response DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<RestaurantVM>> GetRestaurantById(Guid id)
        {
            var restaurant = await _unitOfWork.Repository<Restaurant, Guid>().GetById(id);

            var MappedRestaurant = new RestaurantVM()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Email = restaurant.Email,
                Street = restaurant.Address.Street,
                Zipcode = restaurant.Address.ZipCode,
                HasDelivery = restaurant.HasDelivery,
                PhoneNumber = restaurant.PhoneNumber,
                Dishes = restaurant.Dishes.Select(dish => new DishVM()
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    RestaurantId = dish.RestaurantId,
                }).ToList()
            };

            var response = new Response<RestaurantVM>();
            response.Data = MappedRestaurant;
            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public async Task<Response<List<RestaurantVM>>> GetRestaurants()
        {
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllAsNoTracking();

            var MappedRestaurants = _mapper.Map<List<RestaurantVM>>(restaurants);

            var response = new Response<List<RestaurantVM>>();
            response.Data = MappedRestaurants;
            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public async Task<Response<List<RestaurantVM>>> GetRestaurantsWithSpecs(RestaurantSpecification spec)
        {
            var RestaurantsSpecs = new RestaurantWithSpecification(spec);
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllWithSpecs(RestaurantsSpecs);

            var MappedRestaurants = _mapper.Map<List<RestaurantVM>>(restaurants);

            var response = new Response<List<RestaurantVM>>();
            response.Data = MappedRestaurants;
            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public async Task<Response<RestaurantVM>> GetRestaurantWithSpecs(RestaurantSpecification spec)
        {
            var RestaurantSpecs = new RestaurantWithSpecification(Guid.Parse(spec.Id));

            var restaurant = await _unitOfWork.Repository<Restaurant, Guid>().GetWithSpecs(RestaurantSpecs);

            var MappedRestaurant = new RestaurantVM()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Email = restaurant.Email,
                Street = restaurant.Address.Street,
                City = restaurant.Address.City,
                State = restaurant.Address.State,
                Zipcode = restaurant.Address.ZipCode,
                HasDelivery = restaurant.HasDelivery,
                PhoneNumber = restaurant.PhoneNumber,
                Dishes = restaurant.Dishes.Select(dish => new DishVM()
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    RestaurantId = dish.RestaurantId,
                }).ToList()
            };

            var response = new Response<RestaurantVM>();
            response.Data = MappedRestaurant;
            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public async Task<Response<PaginatedResultDto<RestaurantVM>>> GetRestaurantsPaginatedWithSpecs(RestaurantSpecificationWithPagination spec)
        {
            var RestaurantsSpecs = new RestaurantWithSpecification(spec);
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllWithSpecs(RestaurantsSpecs);

            var MappedRestaurants = _mapper.Map<List<RestaurantVM>>(restaurants);

            var RestrauntsCount = await _unitOfWork.Repository<Restaurant, Guid>().GetCountAsync(RestaurantsSpecs);

            var response = new Response<PaginatedResultDto<RestaurantVM>>();

            response.Data = new PaginatedResultDto<RestaurantVM>(RestrauntsCount, spec.PageIndex, spec.PageSize, MappedRestaurants);
            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public Response UpdateRestaurant(RestaurantVM restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
