using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleBusinessProcessHistory : BaseModel
    {
        [Key]
        public long VehicleBusinessProHistId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("Vehicle")]
        public long? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Owner")]
        public long? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("District")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}
