namespace WebApi.Endpoints
{
    using Application.Auth.Login;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/auth/login", async (
                [FromQuery] string username,
                [FromQuery] string password,
                ISender sender) =>
            {
                var query = new LoginCommand(username, password);

                return Results.Ok(await sender.Send(query));
            }).WithName("GetProducts").WithOpenApi();
        }
    }
}