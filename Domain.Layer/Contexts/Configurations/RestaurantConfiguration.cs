using Domain.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Contexts.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.OwnsOne(res => res.Address, res => res.WithOwner());
            builder.HasMany(res => res.Dishes).WithOne().HasForeignKey(dish => dish.RestaurantId);
        }
    }
}
