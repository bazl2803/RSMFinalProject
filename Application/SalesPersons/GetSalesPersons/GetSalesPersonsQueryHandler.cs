namespace Application.SalesPersons.GetSalesPersons
{
    using Data;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public sealed class GetSalesPersonsQueryHandler : IRequestHandler<GetSalesPersonsQuery, List<SalesPerson>>
    {
        private readonly IApplicationDbContext _context;

        public GetSalesPersonsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<SalesPerson>> Handle(GetSalesPersonsQuery request, CancellationToken cancellationToken)
        {
            return _context.SalesPersons.ToListAsync(cancellationToken);
        }
    }
}