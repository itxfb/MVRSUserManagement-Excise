using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleScannedDocuments
    {
        public long? VehicleDocumentId { get; set; }
        public long? ApplicationId { get; set; }
        public long? VehicleId { get; set; }
        public long? VehicleDocumentTypeId { get; set; }
        public string VehicleDocumentType { get; set; }
        public int? TotalPages { get; set; }
        public string UploadedFileName { get; set; }
        public string FileName { get; set; }

    }
}
