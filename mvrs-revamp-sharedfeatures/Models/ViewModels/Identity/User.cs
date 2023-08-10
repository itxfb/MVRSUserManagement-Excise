using Models.DatabaseModels.Authentication;
using System.Collections.Generic;

namespace Models.ViewModels.Identity
{
    public class VwUser
    {
        public long UserId { get; set; }

        public long? UserDistrictId { get; set; }

        public long? UserSiteId { get; set; }
        public long? UserTypeId { get; set; }
        public string? UserType { get; set; }
        public long? UserStatusId { get; set; }
        public string? UserStatus { get; set; }

        public List<Role>? UserRoles { get; set; }

        public string? ClientIP { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? FullName { get; set; }
    }
}
