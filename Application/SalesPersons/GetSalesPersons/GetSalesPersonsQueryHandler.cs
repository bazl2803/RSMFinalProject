namespace Application.SalesPersons.GetSalesPersons
{
    using Abstractions.Messaging;
    using Data;
    using Domain.Abstractions;
    using Domain.Entities;
    using Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public sealed class GetSalesPersonsQueryHandler : IQueryHandler<GetSalesPersonsQuery, List<SalesPerson>>
    {
        private readonly ISalesPersonRepository _repository;

        public GetSalesPersonsQueryHandler(ISalesPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<SalesPerson>>> Handle(
            GetSalesPersonsQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}