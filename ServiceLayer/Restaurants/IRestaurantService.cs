using Common.Layer;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Pagination;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Restaurants
{
    public interface IRestaurantService
    {
        Task<Response<List<RestaurantDto>>> GetRestaurants();
        Task<Response<List<RestaurantDto>>> GetRestaurantsWithSpecs(RestaurantSpecification spec);
        Task<Response<RestaurantDto>> GetRestaurantWithSpecs(RestaurantSpecification spec);

        Task<Response<RestaurantDto>> GetRestaurantById(Guid id);
        Task<Response<PaginatedResultDto<RestaurantDto>>> GetRestaurantsPaginatedWithSpecs(RestaurantSpecificationWithPagination spec);
        Task<Response> CreateRestaurant(CreateRestaurantDto restaurant);
        Response UpdateRestaurant(RestaurantDto restaurant);
        Response DeleteRestaurant(Guid id);
    }
}
