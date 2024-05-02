namespace Application.Auth.Register
{
    using Domain.Entities;
    using MediatR;

    public record RegisterCommand(string Username, string Password) : IRequest<Unit>;
}