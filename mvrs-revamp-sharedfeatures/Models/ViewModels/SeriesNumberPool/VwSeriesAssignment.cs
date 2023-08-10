using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.SeriesNumberPool.Core
{
    public class VwSeriesAssignment
    {
        public long SeriesAssignmentId { get; set; }
        public long SeriesCategoryId { get; set; }
        public string SeriesCategory { get; set; }
        public long SeriesId { get; set; }

        [StringLength(100)]
        public string SeriesName { get; set; }

        public long SeriesConsumerId { get; set; }

        [StringLength(100)]
        public string SeriesConsumerName { get; set; }
    }
}
