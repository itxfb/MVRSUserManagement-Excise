using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwKeeper : CommonFeature
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? ApplicationPhaseId { get; set; }

        [Required]
        public long? KeeperId { get; set; }

        [Required]
        public long? OwnerId { get; set; }

        public VwPerson Person { get; set; }

        [JsonIgnore]
        public long? VehicleId { get; set; }
    }
}
