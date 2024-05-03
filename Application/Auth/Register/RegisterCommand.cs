namespace Application.Auth.Register
{
    using Abstractions.Messaging;
    using Domain.Entities;
    using MediatR;

    public record RegisterCommand(string Username, string Password) : ICommand<User>;
}