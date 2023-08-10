using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OakleyShop.Domain.Entities;

namespace OakleyShop.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
               .HasKey(key => key.Id);

            builder
                .Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
               .Property(p => p.Description)
               .HasMaxLength(100)
               .IsRequired();

            builder
                .HasMany(c => c.Products)
                .WithOne(c => c.Category);

        }
    }
}
