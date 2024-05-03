namespace Presentation.Product
{
    using Application.Data;
    using Application.Products.GetProducts;
    using Carter;
    using Carter.OpenApi;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class ProductEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products");

            group.MapGet("/GetProducts", async ([FromServices] ISender sender) =>
                {
                    var query = new GetProductsQuery();
                    var result = await sender.Send(query);
                    return result.IsSuccess
                        ? TypedResults.Ok(result.Value)
                        : Results.NoContent();
                })
                .WithName("GetProducts")
                .WithTags("Product")
                .IncludeInOpenApi()
                .RequireAuthorization();
        }
    }
}