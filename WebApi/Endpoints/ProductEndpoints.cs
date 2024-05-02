namespace WebApi.Endpoints
{
    using Application.Data;
    using Application.Products.GetProducts;
    using Application.Sales.GetSalesSummary;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/GetProducts", async (
                IApplicationDbContext context,
                ISender sender) =>
            {
                var query = new GetProductsQuery();
                
                return Results.Ok(await sender.Send(query));
            }).WithName("GetProducts").WithOpenApi();
        }
    }
}