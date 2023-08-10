using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Biometric
{
    public class VwVehicleInfoIM
    {
        public string RegNo { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public long? MvrsTransId { get; set; }
    }
}
