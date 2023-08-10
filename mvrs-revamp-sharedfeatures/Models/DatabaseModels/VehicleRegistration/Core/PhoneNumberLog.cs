using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class PhoneNumberLog : BaseModel
    {
        [Key]
        public long PhoneNumberLogId { get; set; }

        [ForeignKey("PhoneNumber")]
        public long PhoneNumberId { get; set; }
        public virtual PhoneNumber PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumberValue { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("PhoneNumberType")]
        public long PhoneNumberTypeId { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }

        [ForeignKey("Person")]
        public long? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Business")]
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}
