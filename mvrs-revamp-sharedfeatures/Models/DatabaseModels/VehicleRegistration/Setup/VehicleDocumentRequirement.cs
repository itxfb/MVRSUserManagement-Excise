using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class VehicleDocumentRequirement
    {
        public long Id { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("VehicleDocumentType")]
        public long VehicleDocumentTypeId { get; set; }
        public virtual VehicleDocumentType VehicleDocumentType { get; set; }
    }
}
