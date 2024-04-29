namespace Domain.Entities
{
    using Abstractions;

    public class Address : Entity<int>
    {
        public string AddressLine1 { get; init; } = string.Empty;
        public string AddressLine2 { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
    }
}