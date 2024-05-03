namespace Application.Auth.Login
{
    using Abstractions.Messaging;
    using MediatR;

    public record LoginCommand(string Username, string Password) : ICommand<string>;
}