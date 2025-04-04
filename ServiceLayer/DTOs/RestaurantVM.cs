using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.ViewModels
{
    public class RestaurantVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int Zipcode { get; set; }
        public bool HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<DishVM> Dishes { get; set; } = [];
    }
}
