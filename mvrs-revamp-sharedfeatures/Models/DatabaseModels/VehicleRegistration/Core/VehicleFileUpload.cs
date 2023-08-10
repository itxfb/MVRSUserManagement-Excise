using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleFileUpload : BaseModel
    {
        [Key]
        public long FileUploadId { get; set; }

        //[Required]
        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(20)]
        public string FileExtension { get; set; }

        [StringLength(50)]
        public string MIMEType { get; set; }
        public int TotalPages { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }


        [ForeignKey("VehicleDocumentType")]
        public long VehicleDocumentTypeId { get; set; }
        public virtual VehicleDocumentType VehicleDocumentType { get; set; }



        
    }
}
