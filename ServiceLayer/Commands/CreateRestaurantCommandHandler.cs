using AutoMapper;
using Common.Layer;
using Data.Layer.Contexts;
using Domain.Layer.Entities;
using MediatR;
using Repository.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Commands
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Response>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IMapper mapper, IUnitOfWork<RestaurantDBContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var restaurantEntity = _mapper.Map<Restaurant>(request);

                var result = await _unitOfWork.Repository<Restaurant, Guid>().Create(restaurantEntity);

                if (result != Guid.Empty)
                {
                    await _unitOfWork.CompleteAsync();
                    return new Response() { Status = true, Message = "Success", Id = result };
                }
                else
                {
                    return new Response() { Status = false, Message = "Failed", Id = Guid.Empty };
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Id = Guid.Empty,
                    Status = false,
                    Message = ex.Message
                };
            }
        }
    }
}
