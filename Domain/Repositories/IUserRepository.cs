namespace Domain.Repositories
{
    using Entities;

    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void Add(User user);
    }
}