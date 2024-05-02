namespace Domain.Entities
{
    using Abstractions;

    public class Address : Entity
    {
        // Properties
        public string AddressLine1 { get; init; } = string.Empty;
        public string AddressLine2 { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        
        // Navigation Properties
        public IEnumerable<SalesOrderHeader> BillToSalesOrderHeaders { get; } = new List<SalesOrderHeader>();
        public IEnumerable<SalesOrderHeader> ShipToSalesOrderHeaders { get; } = new List<SalesOrderHeader>();
    }
}