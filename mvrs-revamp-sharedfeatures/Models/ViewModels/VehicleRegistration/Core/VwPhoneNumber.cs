using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwPhoneNumber : CommonFeature
    {
        public long PhoneNumberId { get; set; }

        [Required]
        [StringLength(500)]
        public string PhoneNumberValue { get; set; }

        public long CountryId { get; set; }

        [Required]
        public long? PhoneNumberTypeId { get; set; }

        public string PhoneNumberType { get; set; }

        [JsonIgnore]
        public long PersonId { get; set; }

        [JsonIgnore]
        public long BusinessId { get; set; }
    }
}
