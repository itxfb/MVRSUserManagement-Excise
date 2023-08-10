using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels.Biometric
{
    public class VwBiometricInfo
    {
        public string RegNo { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public long? MvrsTransId { get; set; }

        [Required]
        public long? NadraTransId { get; set; }

        [Required]
        public long? NadraFranchiseId { get; set; }

        [Required]
        public bool? IsVerified { get; set; }
    }
}
