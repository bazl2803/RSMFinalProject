namespace Application.ProductCategories.GetProductCategories
{
    using Data;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public sealed class
        GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, List<ProductCategory>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ProductCategory>> Handle(GetProductCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return _context.ProductCategories.ToListAsync(cancellationToken);
        }
    }
}