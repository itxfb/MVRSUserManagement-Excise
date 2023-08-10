using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class RoleResourceRightsHistory : BaseModel
    {
        [Key]
        public long RoleRightsHistoryId { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Resource")]
        public long ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
