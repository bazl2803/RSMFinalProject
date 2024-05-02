namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address), "Person");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("AddressID");
            builder.Property(e => e.AddressLine1);
            builder.Property(e => e.AddressLine2);
            builder.Property(e => e.City);

            builder
                .HasMany(e => e.BillToSalesOrderHeaders)
                .WithOne(e => e.BillToAddress)
                .HasForeignKey(e => e.BillToAddressID);

            builder.HasMany(e => e.ShipToSalesOrderHeaders)
                .WithOne(e => e.ShipToAddress)
                .HasForeignKey(e => e.ShipToAddressID);
        }
    }
}