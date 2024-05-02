namespace Domain.Entities
{
    using Abstractions;

    public class SalesOrderHeader : Entity
    {
        // Properties
        public DateTime OrderDate { get; init; }

        // Foreign Keys
        public int? SalesPersonID { get; init; }
        public int? TerritoryID { get; init; }
        public int? BillToAddressID { get; init; }
        public int? ShipToAddressID { get; init; }

        // Navigation Properties
        public Address? BillToAddress { get; init; }
        public Address? ShipToAddress { get; init; }
        public SalesPerson? SalesPerson { get; init; }
        public IEnumerable<SalesOrderDetail> SalesOrderDetails { get; } = new List<SalesOrderDetail>();
    }
}