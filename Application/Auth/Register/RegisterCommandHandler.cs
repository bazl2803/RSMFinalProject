namespace Application.Auth.Register
{
    using Abstractions.Messaging;
    using Domain.Abstractions;
    using Domain.Entities;
    using Domain.Repositories;
    using MediatR;

    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Username) ||
                    string.IsNullOrWhiteSpace(request.Password))
                {
                    return Result.Failure<User>(
                        new Error(
                            "RegisterCommand",
                            "Username or password aren't must to be null"));
                }

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
                var user = new User { Username = request.Username, PasswordHash = hashedPassword };
                _userRepository.Add(user);

                return user;
            }
            catch (Exception e)
            {
                return Result.Failure<User>(new Error("RegisterCommand", e.Message));
            }                     
        }
    }
}