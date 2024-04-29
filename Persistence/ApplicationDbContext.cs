namespace Infrastructure.Persistence
{
    using Application.Data;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CountryRegion> CountryRegions { get; set; }
    }
}