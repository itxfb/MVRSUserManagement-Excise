using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class AuctionSchedule : BaseModel
    {
        [Key]
        public long AuctionScheduleId { get; set; }

        [ForeignKey("Series")]
        public long SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("AuctionStatus")]
        public long AuctionStatusId { get; set; }
        public virtual AuctionStatus AuctionStatus { get; set; }

        public DateTime RegStartDateTime { get; set; }
        public DateTime RegEndDateTime { get; set; }
        public DateTime AuctionStartDateTime { get; set; }
        public DateTime AuctionEndDateTime { get; set; }
    }
}
