using Models.DatabaseModels.SeriesNumberPool;
using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleRegistrationHistory : BaseModel
    {
        [Key]
        public long VehicleRegHistoryId { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("District")]
        public long RegistrationDistrictId { get; set; }
        public virtual District District { get; set; }

        [StringLength(30)]
        public string RegistrationNo { get; set; }

        public DateTime RegistrationDate { get; set; }

        [ForeignKey("SeriesNumberPool")]
        public long SeriesNumberPoolId { get; set; }
        public virtual SeriesNumberPool.SeriesNumberPool SeriesNumberPool { get; set; }
    }
}
