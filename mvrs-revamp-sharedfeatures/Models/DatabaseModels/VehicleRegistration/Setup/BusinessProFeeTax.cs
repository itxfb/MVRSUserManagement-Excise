using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class BusinessProFeeTax : SetupBaseModel
    {
        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("TaxType")]
        public long TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }

        public bool IsActive { get; set; }
    }
}
