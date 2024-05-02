namespace Application.ProductCategories.GetProductCategories
{
    using Domain.Entities;
    using MediatR;

    public record GetProductCategoriesQuery : IRequest<List<ProductCategory>>;
}