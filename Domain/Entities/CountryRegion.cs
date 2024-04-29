namespace Domain.Entities
{
    using Abstractions;

    public class CountryRegion : Entity<string>
    {
        public string Name { get; init; } = string.Empty;
    }
}