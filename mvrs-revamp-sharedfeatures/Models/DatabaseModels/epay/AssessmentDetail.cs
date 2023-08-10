using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels.epay
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
        public virtual VehicleRegistration.Setup.TaxType TaxType { get; set; }

        public decimal PayableAmount { get; set; }
    }
}
