using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class HPAStatusHistory : BaseModel
    {
        [Key]
        public long HPAStatusHistoryId { get; set; }

        [ForeignKey("HPA")]
        public long HPAId { get; set; }
        public virtual HPA HPA { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("HPAStatus")]
        public long HPAStatusId { get; set; }
        public virtual HPAStatus HPAStatus { get; set; }

        public DateTime HPAStatusDate { get; set; }
    }
}
