using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Address : BaseModel
    {
        [Key]
        public long AddressId { get; set; }

        [Required]
        [StringLength(500)]
        public string AddressDescription { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [ForeignKey("District")]
        public long DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("Tehsil")]
        public long? TehsilId { get; set; }
        public virtual Tehsil Tehsil { get; set; }

        [ForeignKey("AddressType")]
        public long AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }

        [ForeignKey("Person")]
        public long? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Business")]
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }

}
