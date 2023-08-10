using Models.ViewModels.Identity;

namespace SharedLib.Interfaces
{
    public interface ITokenService
    {
        Task<AuthenticationResult> Authenticate(string username, string password);
        Task<AuthenticationResult> AuthenticateClient(string clientId, string clientSecret, string clientIP);
        TokenInfo ValidateToken(string token);
    }
}
