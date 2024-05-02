namespace Domain.Entities
{
    using Abstractions;

    public class SalesOrderDetail : Entity
    {
        // Properties
        public short OrderQty { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal LineTotal { get; init; }

        // Foreign Keys
        public int SalesOrderID { get; init; }
        public int ProductID { get; init; }

        // Navigation Properties
        public SalesOrderHeader SalesOrderHeader { get; init; }
        public Product Product { get; init; }
    }
}