namespace Application.Sales.GetSalesSummary
{
    using Domain.Entities;
    using MediatR;

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
        string? SortOrder) : IRequest<List<SalesSummaryResponse>>;
}