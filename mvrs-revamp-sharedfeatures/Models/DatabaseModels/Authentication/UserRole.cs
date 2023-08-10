using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class UserRole : BaseModel
    {
        [Key]
        public long UserRoleId { get; set; }

        [ForeignKey("AssociatedUser")]
        public long UserId { get; set; }
        public virtual User AssociatedUser { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        public bool IsTimeBased { get; set; }

        public DateTime? ExpiryDateTime { get; set; }
    }
}
