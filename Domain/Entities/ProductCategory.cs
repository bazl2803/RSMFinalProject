namespace Domain.Entities
{
    using Abstractions;

    public class ProductCategory : Entity
    {
        // Properties
        public string Name { get; init; } = string.Empty;

        // Navigation Properties
        public IEnumerable<ProductSubcategory> ProductSubcategories { get; } = new List<ProductSubcategory>();
    }
}