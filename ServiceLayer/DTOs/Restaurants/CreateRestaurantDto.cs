using Domain.Layer;
using Service.Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.DTOs.Restaurants
{
    public class CreateRestaurantDto
    {
        public Guid Id { get; set; }
        [MaxLength(50), MinLength(3), Required]
        public string? Name { get; set; }
        [MaxLength(200), MinLength(3), Required]
        public string? Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        [Required]
        public bool HasDelivery { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}
