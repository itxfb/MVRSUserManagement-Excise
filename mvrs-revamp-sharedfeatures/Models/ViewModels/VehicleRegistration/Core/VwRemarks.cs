using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwRemarks : CommonFeature
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        [StringLength(500)]
        public string RemarksStatement { get; set; }

        public string UserRole { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
