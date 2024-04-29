namespace Domain.Entities
{
    using Abstractions;

    public class SalesOrderHeader : Entity<int>
    {
        public byte? RevisionNumber { get; init; }
        public DateTime OrderDate { get; init; }
        public int? CustomerId { get; init; }
        public int? SalesPersonID { get; init; }
        public int? TerritoryID { get; init; }
        public int? BillToAddressID { get; init; }
        public int? ShipToAddressID { get; init; }
    }
}