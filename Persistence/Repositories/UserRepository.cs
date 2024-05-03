namespace Persistence.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public User GetUserByUsername(string username)
        {
            var user = _users.Where(u => u.Username == username).FirstOrDefault();
            if (user is null) throw new Exception("User not found");
            return user;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}