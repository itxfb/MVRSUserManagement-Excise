using Models.DatabaseModels.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class SiteOffice : SetupBaseModel
    {

        [ForeignKey("District")]
        public long DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}
