using Models.DatabaseModels.VehicleRegistration.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class AdvanceReservation : BaseModel
    { 
        [Key]
        public long AdvanceReservationId { get; set; }

        [ForeignKey("AdvanceReservationStatus")]
        public long AdvanceReservationStatusId { get; set; }
        public virtual AdvanceReservationStatus AdvanceReservationStatus { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("SeriesNumberPool")]
        public long SeriesNumberPoolId { get; set; }
        public virtual SeriesNumberPool SeriesNumberPool { get; set; }

        [StringLength(50)]
        public string ChasisNumber { get; set; }
        public long ReservePrice { get; set; }
    }
}
