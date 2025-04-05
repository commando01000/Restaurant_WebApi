using Common.Layer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Commands
{
    public class DeleteRestaurantCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
