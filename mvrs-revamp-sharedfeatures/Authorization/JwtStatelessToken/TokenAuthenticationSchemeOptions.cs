using Microsoft.AspNetCore.Authentication;
using SharedLib.Security;

namespace AuthorizationService.JwtStatelessToken
{
    public class TokenAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public const string Name = AuthenticationSchemes.JWT_BEARER_TOKEN_STATELESS;
    }
}
