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
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRestaurantCommand, Response>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateRequestCommandHandler(IUnitOfWork<RestaurantDBContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var restaurant = _mapper.Map<Restaurant>(request);

                 await _unitOfWork.Repository<Restaurant, Guid>().Update(restaurant);
                var res = await _unitOfWork.CompleteAsync();

                if (res > 0)
                {
                    return new Response() { Status = true, Message = "Success", Id = request.Id };
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
