namespace Application.Sales.GetSalesSummary
{
    public record SalesSummaryResponse(
        int ID,
        string ProductName,
        string? ProductCategoryName,
        decimal Total,
        string? SalesPersonName,
        DateTime OrderDate,
        string ShipToAddress,
        string BillToAddress);
}