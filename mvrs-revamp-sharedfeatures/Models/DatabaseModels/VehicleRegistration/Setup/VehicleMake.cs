using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class VehicleMake : SetupBaseModel
    {
        [ForeignKey("VehicleMaker")]
        public long? VehicleMakerId { get; set; }
        public virtual VehicleMaker VehicleMaker { get; set; }
    }
}
