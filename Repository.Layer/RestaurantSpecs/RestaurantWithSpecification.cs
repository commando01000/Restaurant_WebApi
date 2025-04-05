using Domain.Layer.Entities;
using Repository.Layer.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.RestaurantSpecs
{
    public class RestaurantWithSpecification : BaseSpecifications<Restaurant>
    {
        public RestaurantWithSpecification(RestaurantSpecification spec) : base(
            res => (string.IsNullOrEmpty(spec.Search) || res.Name.ToLower().Contains(spec.Search.ToLower())) &&
            (!spec.HasDelivery.HasValue || res.HasDelivery == spec.HasDelivery) &&
            (string.IsNullOrEmpty(spec.PhoneNumber) || res.PhoneNumber.Contains(spec.PhoneNumber)) &&
            (string.IsNullOrEmpty(spec.Name) || res.Name.Contains(spec.Name)) &&
            (string.IsNullOrEmpty(spec.Email) || res.Email.Contains(spec.Email))
            )
        {
            AddInclude(res => res.Dishes);

            // Apply sorting
            if (!string.IsNullOrEmpty(spec.Sort))
            {
                switch (spec.Sort.ToLower()) // Case-insensitive sorting
                {
                    case "titleAsc":
                        AddOrderByAsc(res => res.Name);
                        break;
                    case "titleDesc":
                        AddOrderByDesc(res => res.Name);
                        break;
                    // Add more sorting options as needed
                    default:
                        AddOrderByAsc(res => res.Name); // Default sorting
                        break;
                }
            }
        }

        public RestaurantWithSpecification(RestaurantSpecificationWithPagination spec) : base(
            res => (string.IsNullOrEmpty(spec.Search) || res.Name.ToLower().Contains(spec.Search.ToLower())) &&
            (!spec.HasDelivery.HasValue || res.HasDelivery == spec.HasDelivery) &&
            (string.IsNullOrEmpty(spec.PhoneNumber) || res.PhoneNumber.Contains(spec.PhoneNumber)) &&
            (string.IsNullOrEmpty(spec.Name) || res.Name.Contains(spec.Name)) &&
            (string.IsNullOrEmpty(spec.Email) || res.Email.Contains(spec.Email))
            )
        {
            AddInclude(res => res.Dishes);
            ApplyPaging(spec.PageSize * (spec.PageIndex - 1), spec.PageSize); // Apply pagination
            // Apply sorting
            if (!string.IsNullOrEmpty(spec.Sort))
            {
                switch (spec.Sort.ToLower()) // Case-insensitive sorting
                {
                    case "titleAsc":
                        AddOrderByAsc(res => res.Name);
                        break;
                    case "titleDesc":
                        AddOrderByDesc(res => res.Name);
                        break;
                    // Add more sorting options as needed
                    default:
                        AddOrderByAsc(res => res.Name); // Default sorting
                        break;
                }
            }
        }
        public RestaurantWithSpecification(Guid? Id) : base(res => res.Id == Id)
        {
            AddInclude(res => res.Dishes);
        }
    }
}
