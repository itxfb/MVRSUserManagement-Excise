using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwTempOwner_v1 : CommonFeature
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? BusinessProcessId { get; set; }

        [Required]
        public long? OwnerId { get; set; }

        [Required]
        public long? OwnerTypeId { get; set; }
        public string OwnerType { get; set; }

        [Required]
        public long? OwnerTaxGroupId { get; set; }

        public long? VehicleId { get; set; }

        public long? SellerId { get; set; }
        public bool IsHPA { get; set; }

        public string OwnerTaxGroup { get; set; }

        public List<VwPerson> Persons { get; set; }

        public VwBusiness Business { get; set; }
    }
}
