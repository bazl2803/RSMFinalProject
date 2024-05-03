namespace Application.Products.GetProducts
{
    using Abstractions.Messaging;
    using Domain.Entities;

    public record GetProductsQuery : IQuery<List<Product>>;
}