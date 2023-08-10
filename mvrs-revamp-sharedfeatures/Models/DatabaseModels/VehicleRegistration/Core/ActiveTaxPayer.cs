using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class ActiveTaxPayer : BaseModel
    {
        [Key]
        public long ActiveTaxPayerId { get; set; }

        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(20)]
        public string FTN { get; set; }

        [StringLength(200)]
        public string FilerName { get; set; }
    }
}
