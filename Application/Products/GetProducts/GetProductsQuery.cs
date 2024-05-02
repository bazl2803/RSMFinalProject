namespace Application.Products.GetProducts
{
    using Domain.Entities;
    using MediatR;

    public record GetProductsQuery : IRequest<List<Product>>;
}