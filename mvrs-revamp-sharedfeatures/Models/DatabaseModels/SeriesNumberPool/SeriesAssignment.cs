using Models.DatabaseModels.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class SeriesAssignment : BaseModel
    {
        [Key]
        public long SeriesAssignmentId { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("Series")]
        public long SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("SeriesConsumer")]
        public long SeriesConsumerId { get; set; }
        public virtual User SeriesConsumer { get; set; }
    }
}
