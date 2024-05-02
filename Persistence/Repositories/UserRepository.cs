namespace Persistence.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public User GetUserByUsername(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user is null) throw new Exception("User not found");
            return user;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}