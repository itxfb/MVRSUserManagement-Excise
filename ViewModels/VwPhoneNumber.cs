using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.ViewModels
{
    public class VwPhoneNumber
    {
        public long PhoneNumberId { get; set; }

        [Required]
        [StringLength(500)]
        public string PhoneNumberValue { get; set; }

        public long? CountryId { get; set; }

        [Required]
        public long PhoneNumberTypeId { get; set; }

        public string? PhoneNumberType { get; set; }

        [JsonIgnore]
        public long? PersonId { get; set; }

        [JsonIgnore]
        public long? BusinessId { get; set; }
    }
}
