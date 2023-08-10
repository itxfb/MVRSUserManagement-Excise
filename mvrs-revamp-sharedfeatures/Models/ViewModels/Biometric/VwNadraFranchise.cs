using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Biometric
{
    public class VwNadraFranchise
    {
        public long NadraFranchiseId { get; set; }

        [Required]
        [StringLength(100)]
        public string FranchiseName { get; set; }

        [Required]
        [StringLength(100)]
        public string FranchiseShopName { get; set; }

        [Required]
        [StringLength(50)]
        public string FranchiseCellNo { get; set; }
    }
}
