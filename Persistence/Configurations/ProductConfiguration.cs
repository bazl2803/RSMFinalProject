namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProductID");
            builder.Property(e => e.Name);
            builder.Property(e => e.ListPrice);

            builder
                .HasOne(e => e.ProductSubcategory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ProductSubcategoryID);

            builder
                .HasMany(e => e.SalesOrderDetails)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductID);
        }
    }
}