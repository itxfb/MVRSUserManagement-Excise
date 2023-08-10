using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwBusinessRep : CommonFeature
    {
        public long BusinessRepId { get; set; }

        [Required]
        public long? BusinessId { get; set; }

        [Required]
        public long? PersonId { get; set; }

        public VwPerson Person { get; set; }

        [Required]
        public bool? IsOwner { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
