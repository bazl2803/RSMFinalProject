namespace Application.SalesPersons.GetSalesPersons
{
    using Abstractions.Messaging;
    using Domain.Entities;

    public record GetSalesPersonsQuery : IQuery<List<SalesPerson>>;
}