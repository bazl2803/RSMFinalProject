namespace Infrastructure.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SalesOrderID");
            builder.Property(e => e.OrderDate);

            builder.HasMany(e => e.SalesOrderDetails)
                .WithOne()
                .HasForeignKey(detail => detail.SalesOrderID);

            builder.HasOne(e => e.BillAddress)
                .WithMany(e => e.BillingSalesOrderHeaders)
                .HasForeignKey("BillToAddressID");

            builder.HasOne(e => e.ShipAddress)
                .WithMany(e => e.ShippingSalesOrderHeaders)
                .HasForeignKey("ShipToAddressID");

            builder.HasOne(e => e.SalesPerson)
                .WithMany(e => e.SalesOrderHeaders)
                .HasForeignKey("SalesPersonID");
        }
    }
}