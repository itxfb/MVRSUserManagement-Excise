namespace Models.ViewModels.VehicleRegistration.Setup
{
    public class VwBusinessTableAccessLevel
    {
        public long BusinessProcessId { get; set; }
        public string BusinessProcess { get; set; }

        public long BusinessPhaseId { get; set; }
        public string BusinessPhase { get; set; }

        public long BusinessPhaseStatusId { get; set; }
        public string BusinessPhaseStatus { get; set; }

        public long ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }

        public long RoleId { get; set; }
        public string Role { get; set; }

        public long BusinessTableId { get; set; }
        public string BusinessTableName { get; set; }

        public long AccessLevel { get; set; }
    }
}
