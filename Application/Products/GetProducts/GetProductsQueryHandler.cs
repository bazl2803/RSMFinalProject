namespace Application.Products.GetProducts
{
    using Abstractions.Messaging;
    using Data;
    using Domain.Abstractions;
    using Domain.Entities;
    using Domain.Repositories;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetProductsQueryHandler
        : IQueryHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Product>>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}