using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class HPALog : BaseModel
    {
        [Key]
        public long HPALogId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        
        [ForeignKey("HPA")]
        public long HPAId { get; set; }
        public virtual HPA HPA { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Vehicle")]
        public long? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Business")]
        public long SponserBusinessId { get; set; }
        public virtual Business Business { get; set; }

        public DateTime HPADate { get; set; }
        public DateTime HPAStartDate { get; set; }
        public DateTime HPAEndDate { get; set; }

        [Required]
        [StringLength(100)]
        public string LetterNo { get; set; }
        public DateTime LetterDate { get; set; }

        [StringLength(200)]
        public string Terms { get; set; }

        [ForeignKey("HPAStatus")]
        public long HPACurrentStatusId { get; set; }
        public virtual HPAStatus HPAStatus { get; set; }

        public DateTime HPAStatusDated { get; set; }
    }
}
