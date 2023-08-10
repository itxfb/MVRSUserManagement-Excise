using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleDocument : BaseModel
    {
        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Key]
        public long VehicleDocumentId { get; set; }

        [ForeignKey("VehicleDocumentType")]
        public long VehicleDocumentTypeId { get; set; }
        public virtual VehicleDocumentType VehicleDocumentType { get; set; }

        [Required]
        public int TotalPages { get; set; }

        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(200)]
        public string FileExtension { get; set; }

        [StringLength(200)]
        public string MIMEType { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }
    }
}
