using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class BusinessSector : SetupBaseModel
    {
        [ForeignKey("BusinessType")]
        public long? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
