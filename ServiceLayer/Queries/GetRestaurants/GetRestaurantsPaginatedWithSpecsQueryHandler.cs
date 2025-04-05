using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Pagination;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurants
{
    public class GetRestaurantsPaginatedWithSpecsQueryHandler : IRequestHandler<GetRestaurantsPaginatedWithSpecsQuery, Response<PaginatedResultDto<RestaurantDto>>>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public GetRestaurantsPaginatedWithSpecsQueryHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<PaginatedResultDto<RestaurantDto>>> Handle(GetRestaurantsPaginatedWithSpecsQuery request, CancellationToken cancellationToken)
        {
            var specs = new RestaurantSpecificationWithPagination()
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                HasDelivery = request.HasDelivery,
                Search = request.Search,
                Sort = request.Sort,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            var RestaurantsSpecs = new RestaurantWithSpecification(specs);
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllWithSpecs(RestaurantsSpecs);

            var MappedRestaurants = _mapper.Map<List<RestaurantDto>>(restaurants);

            var RestrauntsCount = await _unitOfWork.Repository<Restaurant, Guid>().GetCountAsync(RestaurantsSpecs);

            var response = new Response<PaginatedResultDto<RestaurantDto>>();

            response.Data = new PaginatedResultDto<RestaurantDto>(RestrauntsCount, specs.PageIndex, specs.PageSize, MappedRestaurants);
            response.Status = true;
            response.Message = "Success";

            return response;
        }
    }
}
