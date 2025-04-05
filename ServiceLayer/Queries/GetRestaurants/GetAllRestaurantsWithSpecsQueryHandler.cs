using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Restaurants;
using Service.Layer.Queries.GetRestaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries
{
    public class GetAllRestaurantsWithSpecsQueryHandler : IRequestHandler<GetAllRestaurantsWithSpecsQuery, Response<List<RestaurantDto>>>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllRestaurantsWithSpecsQueryHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<List<RestaurantDto>>> Handle(GetAllRestaurantsWithSpecsQuery spec, CancellationToken cancellationToken)
        {
            var specs = new RestaurantSpecification()
            {
                Name = spec.Name,
                Email = spec.Email,
                PhoneNumber = spec.PhoneNumber,
                HasDelivery = spec.HasDelivery,
                Search = spec.Search,
                Sort = spec.Sort,
            };

            var RestaurantSpecs = new RestaurantWithSpecification(specs);

            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAllWithSpecs(RestaurantSpecs);

            var MappedRestaurants = _mapper.Map<List<RestaurantDto>>(restaurants);

            var response = new Response<List<RestaurantDto>>();
            response.Data = MappedRestaurants;
            response.Status = true;
            response.Message = "Success";

            return response;
        }

    }
}
