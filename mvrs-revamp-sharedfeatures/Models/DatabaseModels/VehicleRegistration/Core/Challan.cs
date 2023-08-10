using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Challan : BaseModel
    {
        [Key]
        public long ChallanId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("AssessmentBase")]
        public long AssessmentBaseId { get; set; }
        public virtual AssessmentBase AssessmentBase { get; set; }

        [ForeignKey("ChallanType")]
        public long ChallanTypeId { get; set; }
        public virtual ChallanType ChallanType { get; set; }

        [ForeignKey("ChallanStatus")]
        public long ChallanStatusId { get; set; }
        public virtual ChallanStatus ChallanStatus { get; set; }
        public long TotalAmount { get; set; }
    }
}
