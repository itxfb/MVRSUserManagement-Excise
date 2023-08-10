using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DatabaseModels.Authentication;
using Models.ViewModels.Identity;
using SharedLib.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationService.JwtStatelessToken
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret;
        private readonly string _expDate;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        private AuthenticationTicket GetAuthenticationTicket(Claim[] claims)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, nameof(TokenAuthenticationHandler));
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            AuthenticationTicket authTicket = new AuthenticationTicket(claimsPrincipal, TokenAuthenticationSchemeOptions.Name);

            return authTicket;
        }

        public Task<AuthenticationResult> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> AuthenticateClient(string clientId, string clientSecret, string clientIP)
        {
            throw new NotImplementedException();
        }

        public TokenInfo ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                var userName = jwtToken.Claims.First(x => x.Type == "nameid").Value;
                var userDistrictId = 0;

                var clientIP = string.Empty;

                if (jwtToken.Claims.Any(x => x.Type == "clientIP"))
                {
                    clientIP = jwtToken.Claims.FirstOrDefault(x => x.Type == "clientIP").Value;
                }

                if (jwtToken.Claims.Any(x => x.Type == "UserDistrictId"))
                { 
                    userDistrictId = int.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "UserDistrictId").Value);
                }

                var userRoles = new List<Role>();

                if (jwtToken.Claims.Any(x => x.Type == "RoleId"))
                {
                    var userRoleIds = jwtToken.Claims.First(x => x.Type == "RoleId").Value
                                        .Split(",")
                                        .ToList();


                    userRoleIds.ForEach(x => userRoles.Add(new Role() { RoleId = Convert.ToInt32(x) }));
                }



                return new TokenInfo()
                {
                    Ticket = this.GetAuthenticationTicket(jwtToken.Claims.ToArray()),
                    User = new VwUser()
                    {
                        UserId = userId,
                        UserName = userName,
                        UserDistrictId = userDistrictId == 0 ? null : userDistrictId,
                        UserRoles = userRoles,
                        ClientIP = clientIP
                    }
                };
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }

    }
}
