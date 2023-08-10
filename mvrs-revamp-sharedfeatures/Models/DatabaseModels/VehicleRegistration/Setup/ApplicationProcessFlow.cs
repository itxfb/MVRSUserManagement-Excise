using Models.DatabaseModels.Authentication;
using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class ApplicationProcessFlow : GeneralBaseModel
    {
        public bool IsInitialProcessState { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("CurrentBusinessPhase")]
        public long CurrentBusinessPhaseId { get; set; }
        public virtual BusinessPhase CurrentBusinessPhase { get; set; }

        [ForeignKey("CurrentBusinessPhaseStatus")]
        public long CurrentBusinessPhaseStatusId { get; set; }
        public virtual BusinessPhaseStatus CurrentBusinessPhaseStatus { get; set; }

        [ForeignKey("CurrentApplicationStatus")]
        public long CurrentApplicationStatusId { get; set; }
        public virtual ApplicationStatus CurrentApplicationStatus { get; set; }


        [ForeignKey("BusinessEvent")]
        public long BusinessEventId { get; set; }
        public virtual BusinessEvent BusinessEvent { get; set; }


        [ForeignKey("NextBusinessPhase")]
        public long NextBusinessPhaseId { get; set; }
        public virtual BusinessPhase NextBusinessPhase { get; set; }

        [ForeignKey("NextBusinessPhaseStatus")]
        public long NextBusinessPhaseStatusId { get; set; }
        public virtual BusinessPhaseStatus NextBusinessPhaseStatus { get; set; }


        [ForeignKey("NextApplicationStatus")]
        public long NextApplicationStatusId { get; set; }
        public virtual ApplicationStatus NextApplicationStatus { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
