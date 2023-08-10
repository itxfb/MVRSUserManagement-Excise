namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwApplicationProcessFlow
    {
        public long BusinessProcessId { get; set; }
        public string BusinessProcess { get; set; }

        public long BusinessEventId { get; set; }
        public string BusinessEvent { get; set; }

        public long CurrentBusinessPhaseId { get; set; }
        public string CurrentBusinessPhase { get; set; }

        public long CurrentBusinessPhaseStatusId { get; set; }
        public string CurrentBusinessPhaseStatus { get; set; }

        public long CurrentApplicationStatusId { get; set; }
        public string CurrentApplicationStatus { get; set; }

        public long NextBusinessPhaseId { get; set; }
        public string NextBusinessPhase { get; set; }

        public long NextBusinessPhaseStatusId { get; set; }
        public string NextBusinessPhaseStatus { get; set; }

        public long NextApplicationStatusId { get; set; }
        public string NextApplicationStatus { get; set; }

        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
