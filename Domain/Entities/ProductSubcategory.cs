namespace Domain.Entities
{
    using Abstractions;

    public class ProductSubcategory : Entity
    {
        // Properties
        public string? Name { get; init; }
        public int ProductCategoryID { get; init; }

        // Navigation Properties
        public IEnumerable<Product> Products { get; } = new List<Product>();
        public ProductCategory ProductCategory { get; init; }
    }
}