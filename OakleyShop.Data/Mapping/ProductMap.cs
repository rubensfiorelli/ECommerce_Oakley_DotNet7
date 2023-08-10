using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OakleyShop.Domain.Entities;

namespace OakleyShop.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(key => key.Id);

            builder
                .Property(p => p.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(p => p.Description)
               .HasMaxLength(300)
               .IsRequired();

            builder
              .Property(p => p.ImgUrl)
              .HasMaxLength(300)
              .IsRequired();

            builder
              .Property(p => p.Code)
              .HasMaxLength(12)
              .IsRequired();

            builder
               .Property(p => p.Price)
               .HasPrecision(10, 2);

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
