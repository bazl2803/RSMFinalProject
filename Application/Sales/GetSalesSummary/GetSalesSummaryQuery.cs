namespace Application.Sales.GetSalesSummary
{
    using Abstractions.Messaging;

    public sealed record GetSalesSummaryQuery(
        int? ProductId,
        int? CategoryId,
        int? SalesPersonId,
        decimal? TotalSale,
        DateTime? OrderStartDate,
        DateTime? OrderEndDate,
        int PageSize,
        int? Cursor,
        string? SortColumn,
        string? SortOrder) : IQuery<List<SalesSummaryResponse>>;
}