using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwApplicationPhaseChange
    {
        public long ApplicationId { get; set; }

        public long BusinessProcessId { get; set; }
        public string BusinessProcess { get; set; }

        public long BusinessEventId { get; set; }
        public string BusinessEvent { get; set; }

        public long BusinessPhaseId { get; set; }
        public string BusinessPhase { get; set; }

        public long BusinessPhaseStatusId { get; set; }
        public string BusinessPhaseStatus { get; set; }

        public long ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }

        [StringLength(500)]
        public string RemarksStatement { get; set; }
    }
}
