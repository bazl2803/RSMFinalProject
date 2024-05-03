namespace Presentation.SalesPerson
{
    using Application.SalesPersons.GetSalesPersons;
    using Carter;
    using Carter.OpenApi;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class SalesPersonEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/SalesPerson");

            group.MapGet("/GetSalesPersons", async ([FromServices] ISender sender) =>
                {
                    var query = new GetSalesPersonsQuery();
                    var result = await sender.Send(query);
                    return result.IsSuccess
                        ? TypedResults.Ok(result.Value)
                        : Results.NoContent();
                })
                .WithName("GetSalesPersons")
                .WithTags("SalesPerson")
                .IncludeInOpenApi()
                .RequireAuthorization();
        }
    }
}