using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class Series : BaseModel
    {
        [Key]
        public long SeriesId { get; set; }

        [ForeignKey("SeriesType")]
        public long SeriesTypeId { get; set; }
        public virtual SeriesType SeriesType { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("SeriesStatus")]
        public long SeriesStatusId { get; set; }
        public virtual SeriesStatus SeriesStatus { get; set; }

        [StringLength(100)]
        public string SeriesName { get; set; }
    }
}
