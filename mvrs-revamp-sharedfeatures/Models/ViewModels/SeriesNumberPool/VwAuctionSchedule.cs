using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.SeriesNumberPool.Core
{
    public class VwAuctionSchedule
    {
        public long SeriesCategoryId { get; set; }
        public string SeriesCategory { get; set; }
        public long SeriesId { get; set; }

        [StringLength(100)]
        public string SeriesName { get; set; }
        public DateTime RegStartDateTime { get; set; }
        public DateTime RegEndDateTime { get; set; }
        public DateTime AuctionStartDateTime { get; set; }
        public DateTime AuctionEndDateTime { get; set; }
    }
}
