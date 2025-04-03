using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using Repository.Layer.Interfaces;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;

        public RestaurantService(IUnitOfWork<RestaurantDBContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response AddRestaurant(RestaurantVM restaurant)
        {
            throw new NotImplementedException();
        }

        public Response DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<RestaurantVM>> GetRestaurantById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<RestaurantVM>>> GetRestaurants()
        {
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllAsNoTracking();

            var MappedRestaurants = restaurants.Select(res => new RestaurantVM()
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                Email = res.Email,
                Address = res.Address,
                HasDelivery = res.HasDelivery,
                PhoneNumber = res.PhoneNumber,
                Dishes = res.Dishes
            }).ToList();

            var response = new Response<List<RestaurantVM>>();
            response.Data = MappedRestaurants;
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
