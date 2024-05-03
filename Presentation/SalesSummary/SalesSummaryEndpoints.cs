namespace Presentation.SalesSummary
{
    using Application.Sales.GetRegionalSalesSummary;
    using Application.Sales.GetSalesSummary;
    using Carter;
    using Carter.OpenApi;
    using Mapster;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class SalesSummaryEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/SalesSummary");

            group.MapGet("/GetSalesSummary", async (
                [FromQuery] int? ProductId,
                [FromQuery] int? categoryId,
                [FromQuery] int? salesPerson,
                [FromQuery] decimal? totalSale,
                [FromQuery] DateTime? OrderStartDate,
                [FromQuery] DateTime? OrderEndDate,
                [FromQuery] int pageSize,
                [FromQuery] int? cursor,
                [FromQuery] string? sortColumn,
                [FromQuery] string? sortOrder,
                [FromServices] ISender sender) =>
            {
                var query = new GetSalesSummaryQuery(
                    ProductId,
                    categoryId,
                    salesPerson,
                    totalSale,
                    OrderStartDate,
                    OrderEndDate,
                    pageSize,
                    cursor,
                    sortColumn,
                    sortOrder
                );

                var result = await sender.Send(query);
                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : Results.NoContent();
            }).WithName("GetSalesSummary")
                .WithTags("SalesSummary")
                .IncludeInOpenApi()
                .RequireAuthorization();

            group.MapGet("/RegionalSalesSummary", async ([FromServices] ISender sender) =>
                {
                    var query = new GetRegionalSalesSummaryQuery();
                    var result = await sender.Send(query);
                    return result.IsSuccess
                        ? TypedResults.Ok(result.Value)
                        : Results.NoContent();
                }).WithName("GetRegionalSalesSummary")
                .WithTags("SalesSummary")
                .IncludeInOpenApi()
                .RequireAuthorization();
        }
    }
}