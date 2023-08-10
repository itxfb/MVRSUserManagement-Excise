using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.SeriesNumberPool.Core
{
    public class VwSeries
    {
        public long AuctionScheduleId { get; set; }
        public long SeriesId { get; set; }
        public string SeriesName { get; set; }
        public long SeriesCategoryId { get; set; }
        public string SeriesCategory { get; set; }

        public DateTime RegStartDateTime { get; set; }
        public DateTime RegEndDateTime { get; set; }
        public DateTime AuctionStartDateTime { get; set; }
        public DateTime AuctionEndDateTime { get; set; }

    }
}
