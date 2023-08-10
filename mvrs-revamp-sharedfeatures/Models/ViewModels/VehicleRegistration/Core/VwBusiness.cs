using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwBusiness : CommonFeature
    {
        public long BusinessId { get; set; }

        [Required]
        public long? BusinessTypeId { get; set; }
        public string BusinessType { get; set; }

        [Required]
        public long? BusinessSectorId { get; set; }
        public string BusinessSector { get; set; }

        [Required]
        public long? BusinessStatusId { get; set; }
        public string BusinessStatus { get; set; }

        [StringLength(50)]
        public string BusinessRegNo { get; set; }

        [Required]
        [StringLength(50)]
        public string BusinessName { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(20)]
        public string FTN { get; set; }

        [StringLength(20)]
        public string STN { get; set; }

        public List<VwAddress> Addresses { get; set; }
        public List<VwPhoneNumber> PhoneNumbers { get; set; }
    }
}
