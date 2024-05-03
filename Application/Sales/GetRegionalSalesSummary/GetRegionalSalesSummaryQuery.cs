namespace Application.Sales.GetRegionalSalesSummary
{
    using Abstractions.Messaging;
    using MediatR;

    public sealed record GetRegionalSalesSummaryQuery
        : IQuery<List<RegionalSalesSummaryResponse>>;
}