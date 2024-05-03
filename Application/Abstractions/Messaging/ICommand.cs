namespace Application.Abstractions.Messaging
{
    using Domain.Abstractions;
    using MediatR;

    public interface ICommand : IRequest<Result>;

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
}