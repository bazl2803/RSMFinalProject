namespace Presentation.Authentication
{
    using Application.Auth.Login;
    using Application.Auth.Register;
    using Carter;
    using Carter.OpenApi;
    using Mapster;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class AuthenticationEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/authentication");

            group.MapPost("/login", async (
                    [FromBody] AuthenticationRequest request,
                    [FromServices] ISender sender) =>
                {
                    var command = new LoginCommand(request.Username, request.Password);
                    var result = await sender.Send(command);
                    return result.IsSuccess
                        ? Results.Ok(result.Value)
                        : Results.BadRequest();
                })
                .WithName("Login")
                .WithTags("Authentication")
                .IncludeInOpenApi();

            group.MapPost("/register", async (
                    [FromBody] AuthenticationRequest request,
                    [FromServices] ISender sender) =>
                {
                    RegisterCommand command = request.Adapt<RegisterCommand>();
                    var result = await sender.Send(command);
                    return result.IsSuccess
                        ? Results.Ok(result.Value)
                        : Results.BadRequest();
                })
                .WithName("Register")
                .WithTags("Authentication")
                .IncludeInOpenApi();
        }
    }
}