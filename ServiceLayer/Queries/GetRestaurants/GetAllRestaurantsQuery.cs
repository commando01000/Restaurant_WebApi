using Common.Layer;
using MediatR;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<Response<List<RestaurantDto>>>
    {

    }
}
