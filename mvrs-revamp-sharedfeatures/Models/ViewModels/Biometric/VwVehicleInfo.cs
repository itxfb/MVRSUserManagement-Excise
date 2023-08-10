using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Biometric
{
    public class VwVehicleInfo
    {
        public string RegistrationNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleMaker { get; set; }
        public string ChassisNo { get; set; }
        public string OwnerName { get; set; }
        public string OwnerFatherHusbandName { get; set; }
        public long MvrsTransId { get; set; }
        public string OwnerType { get; set; }
    }
}
