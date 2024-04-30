namespace Domain.Entities
{
    using Abstractions;

    public class SalesPerson : Entity<int>
    {
        // Properties
        public string FirstName { get; init; } = string.Empty;
        public string MiddleName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;

        // Navigation Properties
        public IEnumerable<SalesOrderHeader> SalesOrderHeaders { get; } = new List<SalesOrderHeader>();
    }
}