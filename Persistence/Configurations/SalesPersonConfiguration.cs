namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            builder.ToTable("vSalesPerson", "Sales");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("BusinessEntityID");
            builder.Property(e => e.FirstName);
            builder.Property(e => e.MiddleName);
            builder.Property(e => e.LastName);

            builder
                .HasMany(e => e.SalesOrderHeaders)
                .WithOne(e => e.SalesPerson)
                .HasForeignKey(e => e.SalesPersonID);
        }
    }
}