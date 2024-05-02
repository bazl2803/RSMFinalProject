namespace Persistence.Configurations
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

            builder
                .HasMany(e => e.SalesOrderDetails)
                .WithOne(e => e.SalesOrderHeader)
                .HasForeignKey(e => e.SalesOrderID);

            builder.HasOne(e => e.BillToAddress)
                .WithMany(e => e.BillToSalesOrderHeaders)
                .HasForeignKey(e => e.BillToAddressID);

            builder.HasOne(e => e.ShipToAddress)
                .WithMany(e => e.ShipToSalesOrderHeaders)
                .HasForeignKey(e => e.BillToAddressID);

            builder.HasOne(e => e.SalesPerson)
                .WithMany(e => e.SalesOrderHeaders)
                .HasForeignKey(e => e.SalesPersonID);
        }
    }
}