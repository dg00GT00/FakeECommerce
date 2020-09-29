using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Description).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(product => product.PictureUrl).IsRequired();
        }
    }
}