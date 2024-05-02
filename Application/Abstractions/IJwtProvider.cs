namespace Application.Abstractions
{
    using Domain.Entities;

    public interface IJwtProvider
    {
        string Generate(User user);
    }
}