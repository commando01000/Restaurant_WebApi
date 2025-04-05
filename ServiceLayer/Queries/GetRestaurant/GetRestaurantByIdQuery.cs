using Common.Layer;
using MediatR;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurant
{
    public class GetRestaurantByIdQuery : IRequest<Response<RestaurantDto>>
    {
        public Guid Id { get; set; }
    }
}
