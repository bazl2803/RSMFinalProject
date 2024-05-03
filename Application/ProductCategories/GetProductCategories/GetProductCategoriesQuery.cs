namespace Application.ProductCategories.GetProductCategories
{
    using Abstractions.Messaging;
    using Domain.Entities;

    public record GetProductCategoriesQuery : IQuery<List<ProductCategory>>;
}