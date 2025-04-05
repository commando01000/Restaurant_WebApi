using Common.Layer;
using MediatR;
using Service.Layer.DTOs.Pagination;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurants
{
    public class GetRestaurantsPaginatedWithSpecsQuery : IRequest<Response<PaginatedResultDto<RestaurantDto>>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool? HasDelivery { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Sort { get; set; }
        public int pageSize { get; set; } = 6;
        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 50;
        private string _search;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
