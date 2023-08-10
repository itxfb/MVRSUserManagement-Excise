using Models.DatabaseModels.Setup;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class RegFeePenaltyRate : SetupBaseModel
    {
        public int MinDays { get; set; }
        public int MaxDays { get; set; }
        public long PenaltyRate { get; set; }
        public bool IsActive { get; set; }
    }
}
