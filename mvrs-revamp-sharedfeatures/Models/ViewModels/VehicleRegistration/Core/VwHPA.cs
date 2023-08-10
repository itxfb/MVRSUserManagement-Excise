using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwHPA : CommonFeature
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? ApplicationStateId { get; set; }

        [Required]
        public long? OwnerId { get; set; }
        public VwBusiness SponserBusiness { get; set; }
        public long? SponserBusinessId { get; set; }

        [Required]
        public long? HPAId { get; set; }

        public System.DateTime HPADate { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string HPALetterNo { get; set; }

        [Required]
        public DateTime? LetterDate { get; set; }

        [StringLength(100)]
        public string HPATerms { get; set; }

        [Required]
        public long? HPAStatusId { get; set; }

        [Required]
        public DateTime? HPAStatusDated { get; set; }
    }
}
