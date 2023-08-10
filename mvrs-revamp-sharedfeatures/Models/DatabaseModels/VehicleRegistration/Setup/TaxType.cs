using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class TaxType : SetupBaseModel
    {
        [ForeignKey("TaxRule")]
        public long? TaxRuleId { get; set; }
        public virtual TaxRule TaxRule { get; set; }

        public int Order { get; set; }
    }
}
