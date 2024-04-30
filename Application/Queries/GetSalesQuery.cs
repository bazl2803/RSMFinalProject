namespace Application.Queries
{
    public sealed record GetSalesQuery(
        string? ProductName,
        string? ProductCategory,
        string? TotalGreaterThan,
        string? SalesPerson,
        DateTime? OrderStartDate,
        DateTime? OrderEndDate,
        int PageSize,
        int? Cursor);
}