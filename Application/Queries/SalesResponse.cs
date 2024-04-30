namespace Application.Queries
{
    public class SalesResponse
    {
        public string ProductName { get; init; } = string.Empty;
        public string ProductCategory { get; init; } = string.Empty;
        public decimal TotalSale { get; init; }
        public string SalesPersonName { get; init; } = string.Empty;
        public DateTime OrderDate { get; init; }
        public string ShippingAddress { get; init; } = string.Empty;
        public string BillingAddress { get; init; } = string.Empty;
    }
}