using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class BusinessLog : BaseModel
    {
        [Key]
        public long BusinessLogId { get; set; }
        
        [ForeignKey("Business")]
        public long BusinessId { get; set; }
        public virtual Business Business { get; set; }
        
        [ForeignKey("BusinessType")]
        public long BusinessTypeId { get; set; }
        public virtual BusinessType BusinessType { get; set; }
        
        [ForeignKey("BusinessSector")]
        public long BusinessSectorId { get; set; }
        public virtual BusinessSector BusinessSector { get; set; }
        
        [ForeignKey("BusinessStatus")]
        public long BusinessStatusId { get; set; }
        public virtual BusinessStatus BusinessStatus { get; set; }

        [StringLength(50)]
        public string BusinessRegNo { get; set; }

        [Required]
        [StringLength(50)]
        public string BusinessName { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(20)]
        public string FTN { get; set; }

        [StringLength(20)]
        public string STN { get; set; }

        [StringLength(500)]
        public string AccountPassword { get; set; }
    }
}
