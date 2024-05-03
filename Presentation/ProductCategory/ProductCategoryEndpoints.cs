namespace Presentation.Category
{
    using Application.ProductCategories.GetProductCategories;
    using Carter;
    using Carter.OpenApi;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class ProductCategoryEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/ProductCategory");

            group.MapGet("/GetProductCategories", async ([FromServices] ISender sender) =>
            {
                var query = new GetProductCategoriesQuery();
                var result = await sender.Send(query);
                return result.IsSuccess
                    ? TypedResults.Ok(result.Value)
                    : Results.NoContent();
            })
                .WithName("GetProductsCategories")
                .WithTags("ProductCategory")
                .IncludeInOpenApi()
                .RequireAuthorization();
        }
    }
}