using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SharedLib.Security;

namespace AuthorizationService.JwtStatelessToken
{
    public static class TokenAuthorizationExtensions
    {
        public static void AddStatelessTokenAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(AuthenticationSchemes.JWT_BEARER_TOKEN_STATELESS);
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }
    }
}
