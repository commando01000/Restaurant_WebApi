using Common.Layer;
using MediatR;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurant
{
    public class GetRestaurantWithSpecsQuery : IRequest<Response<RestaurantDto>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool? HasDelivery { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Sort { get; set; }
        private string _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
