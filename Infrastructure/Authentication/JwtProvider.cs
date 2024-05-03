namespace Infrastructure.Authentication
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Application.Abstractions;
    using Domain.Entities;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public sealed class JwtProvider : IJwtProvider
    {
        //private readonly IConfiguration _configuration;
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            //_configuration = configuration;
            _options = options.Value;
        }

        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_options.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}