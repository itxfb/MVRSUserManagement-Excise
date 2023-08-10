using Microsoft.AspNetCore.Authentication;

namespace Models.ViewModels.Identity
{
    public class TokenInfo
    {
        public TokenInfo() { }

        public DateTime CreatedAt { get; set; }

        public AuthenticationTicket Ticket { get; set; }

        public VwUser User { get; set; }
    }
}
