using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using Repository.Layer.RestaurantSpecs;
using Service.Layer.DTOs.Pagination;
using Service.Layer.DTOs.Restaurants;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurant
{
    public class GetRestaurantWithSpecsHandler : IRequestHandler<GetRestaurantWithSpecsQuery, Response<RestaurantDto>>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public GetRestaurantWithSpecsHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<RestaurantDto>> Handle(GetRestaurantWithSpecsQuery request, CancellationToken cancellationToken)
        {
            var RestaurantSpecs = new RestaurantWithSpecification(Guid.Parse(request.Id));

            var restaurant = await _unitOfWork.Repository<Restaurant, Guid>().GetWithSpecs(RestaurantSpecs);

            var MappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);

            var response = new Response<RestaurantDto>();
            response.Data = MappedRestaurant;
            response.Status = true;
            response.Message = "Success";

            return response;
        }
    }
}
