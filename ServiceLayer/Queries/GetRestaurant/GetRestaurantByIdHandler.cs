using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using Service.Layer.DTOs.Restaurants;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Queries.GetRestaurant
{
    public class GetRestaurantByIdHandler : IRequestHandler<GetRestaurantByIdQuery, Response<RestaurantDto>>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public GetRestaurantByIdHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<RestaurantDto>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _unitOfWork.Repository<Restaurant, Guid>().GetById(request.Id);

            var MappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);

            var response = new Response<RestaurantDto>()
            {
                Data = MappedRestaurant,
                Status = true,
                Message = "Success"
            };

            return response;
        }
    }
}
