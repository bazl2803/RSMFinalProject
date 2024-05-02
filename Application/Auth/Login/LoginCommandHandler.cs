namespace Application.Auth.Login
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Abstractions;
    using BCrypt.Net;
    using Domain.Entities;
    using Domain.Repositories;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IUserRepository userRepository, IConfiguration configuration,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtProvider = jwtProvider;
        }

        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByUsername(request.Username);

            if (BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = _jwtProvider.Generate(user);

            return Task.FromResult(token);
        }
    }
}