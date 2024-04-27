namespace Domain.Entities
{
    using Abstractions;

    public class ProductCategory : Entity<int>
    {
        public string? Name { get; set; }
    }
}