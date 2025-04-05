using Common.Layer;
using MediatR;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Commands
{
    public class UpdateRestaurantCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        [MaxLength(50), MinLength(3)]
        public string? Name { get; set; }
        [MaxLength(200), MinLength(3)]
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public bool? HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}
