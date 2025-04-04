using Common.Layer;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Pagination;
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
        Task<Response<List<RestaurantVM>>> GetRestaurantsWithSpecs(RestaurantSpecification spec);
        Task<Response<RestaurantVM>> GetRestaurantWithSpecs(RestaurantSpecification spec);

        Task<Response<RestaurantVM>> GetRestaurantById(Guid id);
        Task<Response<PaginatedResultDto<RestaurantVM>>> GetRestaurantsPaginatedWithSpecs(RestaurantSpecificationWithPagination spec);
        Response AddRestaurant(RestaurantVM restaurant);
        Response UpdateRestaurant(RestaurantVM restaurant);
        Response DeleteRestaurant(int id);
    }
}
