namespace Domain.Entities
{
    public class User
    {
        public string Username { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
    }
}