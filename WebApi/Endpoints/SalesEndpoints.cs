namespace WebApi.Endpoints
{
    using Application.Commands;
    using Application.Data;
    using Application.Queries;

    public static class SalesEndpoints
    {
        public static void MapSalesEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/GetSalesReport", (IApplicationDbContext context, GetSalesQuery request) =>
            {
                var command = new GetSalesCommand(context).Handle(request);
                return Results.Ok(command);
            }).WithName("GetSalesReport").WithOpenApi();
        }
    }
}