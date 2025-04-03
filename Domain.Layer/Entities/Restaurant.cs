using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Address Address { get; set; }
        public bool HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<Dish> Dishes { get; set; }

    }
}
