namespace Application.Abstractions.Messaging
{
    using MediatR;

    public interface IRequestHandler<in TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    };
}