using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class OwnerTaxGroupFees
    {
        public long Id { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }

        [ForeignKey("TaxType")]
        public long TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }

        public DateTime AppliedFrom { get; set; }
        public long Amount { get; set; }
    }
}
