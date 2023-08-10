using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class AssessmentDetail : BaseModel
    {
        [Key]
        public long AssessmentDetailId { get; set; }

        [ForeignKey("AssessmentBase")]
        public long AssessmentBaseId { get; set; }
        public virtual AssessmentBase AssessmentBase { get; set; }

        [ForeignKey("TaxType")]
        public long TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }

        public decimal PayableAmount { get; set; }
    }
}
