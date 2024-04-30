namespace Domain.Entities
{
    using Abstractions;

    public class Product : Entity<int>
    {
        public string Name { get; init; } = string.Empty;
        public decimal ListPrice { get; init; }
        public int? ProductSubcategoryID { get; init; }

        // Navigation Properties
        public ProductSubcategory? ProductSubcategory { get; init; }
        public IEnumerable<SalesOrderDetail> SalesOrderDetails { get; } = new List<SalesOrderDetail>();
    }
}