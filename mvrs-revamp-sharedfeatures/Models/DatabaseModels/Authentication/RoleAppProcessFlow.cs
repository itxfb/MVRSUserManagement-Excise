using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class RoleAppProcessFlow : BaseModel
    {
        [Key]
        public long RoleAppProcessFlowId { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("ApplicationProcessFlow")]
        public long AppProcessFlowId { get; set; }
        public virtual ApplicationProcessFlow ApplicationProcessFlow { get; set; }
    }
}