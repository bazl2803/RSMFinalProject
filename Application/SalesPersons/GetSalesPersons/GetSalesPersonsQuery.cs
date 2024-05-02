namespace Application.SalesPersons.GetSalesPersons
{
    using Domain.Entities;
    using MediatR;

    public record GetSalesPersonsQuery : IRequest<SalesPerson>, IRequest<List<SalesPerson>>;
}