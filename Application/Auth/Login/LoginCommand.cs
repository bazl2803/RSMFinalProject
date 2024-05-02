namespace Application.Auth.Login
{
    using MediatR;

    public record LoginCommand(string Username, string Password) : IRequest<string>;
}