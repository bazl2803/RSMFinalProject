namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), "Production");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProductCategoryID");
            builder.Property(e => e.Name);

            builder
                .HasMany(e => e.ProductSubcategories)
                .WithOne(e => e.ProductCategory)
                .HasForeignKey(e => e.ProductCategoryID);
        }
    }
}