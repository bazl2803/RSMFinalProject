namespace Application.Auth.Login
{
    using Abstractions;
    using Abstractions.Messaging;
    using BCrypt.Net;
    using Domain.Abstractions;
    using Domain.Repositories;

    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
                return Result.Failure<string>(
                    new Error("LoginCommand", "Invalid credential"));

            var user = _userRepository.GetUserByUsername(request.Username);

            if (!BCrypt.Verify(request.Password, user.PasswordHash))
                return Result.Failure<string>(
                    new Error("RegisterCommand", "Username or password aren't must to be null"));


            var token = _jwtProvider.Generate(user);

            return Result.Success<string>(token).Value;

        }
    }
}