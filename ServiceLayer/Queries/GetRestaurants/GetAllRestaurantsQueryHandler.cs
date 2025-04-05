using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using Service.Layer.DTOs.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurants
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, Response<List<RestaurantDto>>>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRestaurantsQueryHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<RestaurantDto>>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await _unitOfWork.Repository<Restaurant, Guid>().GetAll().ToListAsync();

            var MappedRestaurants = _mapper.Map<List<RestaurantDto>>(restaurants);

            var response = new Response<List<RestaurantDto>>();

            response.Data = MappedRestaurants;
            response.Status = true;
            response.Message = "Success";

            return response;
        }
    }
}
