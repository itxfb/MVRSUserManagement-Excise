using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class OwnerTaxGroup : SetupBaseModel
    {
        [ForeignKey("OwnerType")]
        public long OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }

        public bool IsIncomeTaxExempted { get; set; }
        public bool IsTaxExempted { get; set; }

        [StringLength(10)]
        public string ITExemptedClause { get; set; }

        [StringLength(10)]
        public string TaxExemptedClause { get; set; }
    }
}
