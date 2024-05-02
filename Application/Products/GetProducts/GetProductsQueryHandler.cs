﻿namespace Application.Products.GetProducts
{
    using Data;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetProductsQueryHandler
        : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (request.name != null)
                query = query.Where(e => e.Name == request.name);

            return await query.ToListAsync(cancellationToken);
        }
    }
}