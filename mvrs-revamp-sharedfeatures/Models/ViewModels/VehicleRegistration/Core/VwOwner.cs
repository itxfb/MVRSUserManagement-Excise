using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwOwner : CommonFeature
    {
        public Int64 OwnerId { get; set; }

        [Required]
        public long OwnerTypeId { get; set; }

        [Required]
        public long OwnerTaxGroupId { get; set; }

        public long CountryId { get; set; }

        [Required]
        public long PresentDistrictId { get; set; }


        [Required]
        public long PermanentDistrictId { get; set; }
        


        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string FatherHusbandName { get; set; }

        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string PresentAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string PermanentAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string PresentCity { get; set; }

        [Required]
        [StringLength(50)]
        public string PermanentCity { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber1 { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber2 { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string OldCNIC { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(20)]
        public string Remarks { get; set; }
    }
}
