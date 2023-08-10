using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Application : BaseModel
    {
        [Key]
        public long ApplicationId { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("BusinessPhase")]
        public long BusinessPhaseId { get; set; }
        public virtual BusinessPhase BusinessPhase { get; set; }

        [ForeignKey("BusinessPhaseStatus")]
        public long BusinessPhaseStatusId { get; set; }
        public virtual BusinessPhaseStatus BusinessPhaseStatus { get; set; }

        [ForeignKey("ApplicationStatus")]
        public long ApplicationStatusId { get; set; }
        public virtual ApplicationStatus ApplicationStatus { get; set; }

        [ForeignKey("Vehicle")]
        public long? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Owner")]
        public long? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Seller")]
        public long? SellerId { get; set; }
        public virtual Owner Seller { get; set; }

        [ForeignKey("District")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        public DateTime ReceivedAt { get; set; }
    }
}
