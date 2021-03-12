using System;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(item => item.Subtotal).HasColumnType("decimal(18,2)");
            builder.OwnsOne(
                order => order.ShipToAddress,
                nav => nav.WithOwner());
            builder.Property(order => order.Status)
                .HasConversion(
                    status => status.ToString(),
                    s => (OrderStatus) Enum.Parse(typeof(OrderStatus), s));
            builder.HasMany(order => order.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}