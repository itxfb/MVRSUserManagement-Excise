using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class RoleResourceRight : BaseModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("RoleResource")]
        public long RoleResourceId { get; set; }
        public virtual RoleResource RoleResource { get; set; }

        [ForeignKey("ResourceTypeRight")]
        public long RTRightId { get; set; }
        public virtual ResourceTypeRight ResourceTypeRight { get; set; }
    }
}
