using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Biometric
{
    public class NadraFranchise : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long NadraFranchiseId { get; set; }

        [Required]
        [StringLength(200)]
        public string FranchiseName { get; set; }

        [Required]
        [StringLength(200)]
        public string FranchiseShopName { get; set; }

        [Required]
        [StringLength(50)]
        public string FranchiseCellNo { get; set; }
    }
}
