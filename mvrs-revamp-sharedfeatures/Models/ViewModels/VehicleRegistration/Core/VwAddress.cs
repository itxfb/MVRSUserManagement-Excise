using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwAddress : CommonFeature
    {
        public long AddressId { get; set; }

        [StringLength(500)]
        public string AddressDescription { get; set; }

        [StringLength(50)]
        public string PropertyNo { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public long? PostOfficeId { get; set; }
        public string PostOffice { get; set; }

        [Required]
        public long? DistrictId { get; set; }
        public string District { get; set; }

        public long? TehsilId { get; set; }
        public string Tehsil { get; set; }

        [Required]
        public long AddressTypeId { get; set; }
        public string AddressType { get; set; }

        public long? AddressAreaId { get; set; }
        public string AddressArea { get; set; }

        [JsonIgnore]
        public long? PersonId { get; set; }

        [JsonIgnore]
        public long? BusinessId { get; set; }
    }
}
