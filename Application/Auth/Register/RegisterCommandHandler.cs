namespace Application.Auth.Register
{
    using Domain.Entities;
    using Domain.Repositories;
    using MediatR;

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User { Username = request.Username, PasswordHash = hashedPassword };
            _userRepository.Add(user);

            return Task.FromResult(Unit.Value);
        }
    }
}