using Models.DatabaseModels.Authentication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class BusinessTableAccessLevel : GeneralBaseModel
    {
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

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("BusinessTable")]
        public long BusinessTableId { get; set; }
        public virtual BusinessTable BusinessTable { get; set; }

        [ForeignKey("BusinessTableAccess")]
        public long BusinessTableAccessId { get; set; }
        public virtual BusinessTableAccess BusinessTableAccess { get; set; }
    }
}
