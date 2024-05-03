namespace WebApi.Endpoints
{
    using Application.Data;
    using Application.Sales.GetSalesSummary;
    using Domain.Abstractions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public static class SalesSummaryEndpoints
    {
        public static void MapSaleEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/GetSalesReport", async (
                [FromQuery] int? ProductId,
                [FromQuery] int? categoryId,
                [FromQuery] decimal? totalSale,
                [FromQuery] int? salesPerson,
                [FromQuery] DateTime? OrderStartDate,
                [FromQuery] DateTime? OrderEndDate,
                [FromQuery] int pageSize,
                [FromQuery] int? cursor,
                [FromQuery] string? sortColumn,
                [FromQuery] string? sortOrder,
                [FromServices] ISender sender) =>
            {
                // Populate Query
                var query = new GetSalesSummaryQuery(
                    ProductId,
                    categoryId,
                    salesPerson,
                    totalSale,
                    OrderEndDate,
                    OrderEndDate,
                    pageSize,
                    cursor,
                    sortColumn,
                    sortOrder);

                var response = await sender.Send(query);

                return Results.Ok(response);
            }).WithName("GetSalesReport").WithOpenApi().RequireAuthorization();
        }
    }
}