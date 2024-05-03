namespace Application.Sales.GetRegionalSalesSummary
{
    public sealed record RegionalSalesSummaryResponse(
        string ProductName,
        decimal TotalSales,
        decimal PercentageOfTotalSalesInRegion,
        decimal PercentageOfTotalCategorySalesInRegion);
}