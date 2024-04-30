namespace Infrastructure.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            builder.ToTable(nameof(ProductSubcategory), "Production");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);

            builder.HasMany(e => e.Products)
                .WithOne(e => e.ProductSubcategory)
                .HasForeignKey("ProductSubcategoryID");
        }
    }
}