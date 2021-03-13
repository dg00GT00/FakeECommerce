using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BasketConfiguration : IEntityTypeConfiguration<CustomerBasket>
    {
        public void Configure(EntityTypeBuilder<CustomerBasket> builder)
        {
            builder.Property(basket => basket.ShippingPrice).HasColumnType("decimal(18,2)");
            builder.HasMany(basket => basket.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}