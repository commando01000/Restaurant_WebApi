using Common.Layer;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Restaurants
{
    public interface IRestaurantService
    {
        Task<Response<List<RestaurantVM>>> GetRestaurants();
        Task<Response<RestaurantVM>> GetRestaurantById(int id);
        Response AddRestaurant(RestaurantVM restaurant);
        Response UpdateRestaurant(RestaurantVM restaurant);
        Response DeleteRestaurant(int id);
    }
}
