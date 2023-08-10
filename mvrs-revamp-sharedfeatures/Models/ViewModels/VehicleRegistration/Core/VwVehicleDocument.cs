using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleDocument
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? ApplicationStateId { get; set; }

        [Required]
        public long? VehicleId { get; set; }

        [Required]
        public List<VwVehicleDocumentDetail> VehicleDocumentDetail { get; set; }
    }
    public class VwVehicleDocumentDetail : CommonFeature
    {
        [Required]
        public long? VehicleDocumentTypeId { get; set; }
        public string VehicleDocumentType { get; set; }

        [Required]
        public int? TotalPages { get; set; }
    }
}
