namespace Application.Data
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Address> Addresses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}