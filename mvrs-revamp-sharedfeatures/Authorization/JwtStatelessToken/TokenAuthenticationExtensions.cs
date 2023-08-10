using Microsoft.Extensions.DependencyInjection;
using SharedLib.Security;

namespace AuthorizationService.JwtStatelessToken
{
    public static class TokenAuthenticationExtensions
    {
        public static void AddStatelessTokenAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options => {
                options.DefaultScheme = AuthenticationSchemes.JWT_BEARER_TOKEN_STATELESS;
            })
            .AddScheme<TokenAuthenticationSchemeOptions, TokenAuthenticationHandler>(
                TokenAuthenticationSchemeOptions.Name, option => { }
            );
        }
    }
}
