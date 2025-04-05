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
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRestaurantCommand, Response>
    {
        private readonly IUnitOfWork<RestaurantDBContext> _unitOfWork;

        public DeleteRequestCommandHandler(IUnitOfWork<RestaurantDBContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty) return new Response() { Status = false, Message = "Failed", Id = Guid.Empty };

            var result = await _unitOfWork.Repository<Restaurant, Guid>().GetById(request.Id);
            await _unitOfWork.Repository<Restaurant, Guid>().Delete(result);

            var res = await _unitOfWork.CompleteAsync();
            if (res > 0)
            {
                return new Response() { Status = true, Message = "Success", Id = result.Id };
            }
            else
            {
                return new Response() { Status = false, Message = "Failed", Id = Guid.Empty };
            }
        }
    }
}
