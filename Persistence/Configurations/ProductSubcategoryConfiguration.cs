namespace Persistence.Configurations
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
            builder.Property(e => e.Id).HasColumnName("ProductSubcategoryID");
            builder.Property(e => e.Name);

            builder
                .HasMany(e => e.Products)
                .WithOne(e => e.ProductSubcategory)
                .HasForeignKey(e => e.ProductSubcategoryID);

            builder
                .HasOne(e => e.ProductCategory)
                .WithMany(e => e.ProductSubcategories)
                .HasForeignKey(e => e.ProductCategoryID);
        }
    }
}