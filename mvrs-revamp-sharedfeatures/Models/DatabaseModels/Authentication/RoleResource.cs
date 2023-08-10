using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class RoleResource : BaseModel
    {
        [Key]
        public long RoleResourceId { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Resource")]
        public long ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
