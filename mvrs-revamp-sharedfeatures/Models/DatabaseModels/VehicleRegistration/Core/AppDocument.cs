using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class AppDocument : BaseModel
    {
        [Key]
        public long AppDocumentId { get; set; }

        [Required]
        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [Required]
        [ForeignKey("AppDocumentType")]
        public long AppDocumentTypeId { get; set; }
        public virtual AppDocumentType AppDocumentType { get; set; }

        [Required]
        [ForeignKey("AppDocumentStatus")]
        public long AppDocumentStatusId { get; set; }
        public virtual AppDocumentStatus AppDocumentStatus { get; set; }

        [Required]
        public int TotalPage { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
