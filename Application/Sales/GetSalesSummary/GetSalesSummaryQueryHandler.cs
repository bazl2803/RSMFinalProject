namespace Application.Sales.GetSalesSummary
{
    using System.Linq;
    using Data;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Specifications;

    public sealed class GetSalesSummaryQueryHandler
        : IRequestHandler<GetSalesSummaryQuery, List<SalesSummaryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetSalesSummaryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesSummaryResponse>> Handle(
            GetSalesSummaryQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.SalesOrderDetails.AsQueryable();

            /***
             * Specifications
             */
            var specifications = new List<ISalesSpecification>();

            // Filter by OrderDate
            if (request is { OrderStartDate: not null, OrderEndDate: not null })
                specifications.Add(new SalesSummaryOrderDateSpecification(
                    request.OrderStartDate.Value,
                    request.OrderEndDate.Value));

            // Filter by CategoryName
            if (request.CategoryId.HasValue)
                specifications.Add(new SalesSummaryCategorySpecification(request.CategoryId));

            // Aggregate Specifications
            query = specifications.Aggregate(query,
                (current, criteria) => current.Where(criteria.GetExpression()));

            /*
             * Cursor pagination
             */
            if (request.Cursor != null)
                query = query.Where(e => e.Id > request.Cursor);

            /*
             * Build Response
             */
            var response = await query
                .Take(request.PageSize)
                .Select(e => new SalesSummaryResponse
                (
                    e.Id,
                    e.Product.Name,
                    e.Product.ProductSubcategory.ProductCategory.Name,
                    e.LineTotal,
                    string.Join(" ",
                        e.SalesOrderHeader.SalesPerson.FirstName,
                        e.SalesOrderHeader.SalesPerson.MiddleName,
                        e.SalesOrderHeader.SalesPerson.LastName
                    ).Trim(),
                    e.SalesOrderHeader.OrderDate,
                    e.SalesOrderHeader.BillToAddress.AddressLine1,
                    e.SalesOrderHeader.ShipToAddress.AddressLine1
                ))
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}