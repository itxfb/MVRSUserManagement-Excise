using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class UserRoleHistory : BaseModel
    {
        [Key]
        public long UserRoleHistoryId { get; set; }

        [ForeignKey("AssociatedUser")]
        public long UserId { get; set; }
        public virtual User AssociatedUser { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        [StringLength(20)]
        public string Action { get; set; }  // ASSIGNED, REVOKED
    }
}
