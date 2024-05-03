namespace Application.ProductCategories.GetProductCategories
{
    using Data;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Abstractions.Messaging;
    using Domain.Abstractions;
    using Domain.Repositories;

    public sealed class
        GetProductCategoriesQueryHandler : IQueryHandler<GetProductCategoriesQuery, List<ProductCategory>>
    {
        private readonly IProductCategoryRepository _repository;

        public GetProductCategoriesQueryHandler(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductCategory>>> Handle(GetProductCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}