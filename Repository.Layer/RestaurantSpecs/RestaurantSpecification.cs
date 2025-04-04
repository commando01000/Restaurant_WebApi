﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.RestaurantSpecs
{
    public class RestaurantSpecification
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool? HasDelivery { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Sort { get; set; }
        private string _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
