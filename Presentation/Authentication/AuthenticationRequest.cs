namespace Presentation.Authentication
{
    using Microsoft.AspNetCore.Mvc;

    public record AuthenticationRequest(string Username, string Password);
}