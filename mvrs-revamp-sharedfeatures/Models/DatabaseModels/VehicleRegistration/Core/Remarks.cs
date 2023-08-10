using Models.DatabaseModels.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Remarks : BaseModel
    { 
        [Key]
        public long RemarksId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Owner")]
        public long? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("OwnerGroup")]
        public long? OwnerGroupId { get; set; }
        public virtual OwnerGroup OwnerGroup { get; set; }

        [Required]
        [StringLength(500)]
        public string RemarksStatement { get; set; }

        [ForeignKey("CurrentUserRole")]
        public long RoleId { get; set; }
        public virtual Role CurrentUserRole { get; set; }
    }
}
