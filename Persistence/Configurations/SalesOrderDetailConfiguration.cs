namespace Infrastructure.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            builder.ToTable(nameof(SalesOrderDetail), "Sales");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SalesOrderDetailID");
            builder.Property(e => e.UnitPrice);
            builder.Property(e => e.OrderQty);
            builder.Property(e => e.LineTotal);

            builder.HasOne(e => e.SalesOrderHeader)
                .WithMany(e => e.SalesOrderDetails)
                .HasForeignKey("SalesOrderID");

            builder.HasOne(e => e.Product)
                .WithMany(e => e.SalesOrderDetails)
                .HasForeignKey("ProductID");
        }
    }
}