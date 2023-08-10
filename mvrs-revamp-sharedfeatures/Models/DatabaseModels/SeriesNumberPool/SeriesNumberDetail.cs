using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class SeriesNumberDetail : BaseModel
    {
        [Key]
        public long SeriesNumberDetailId { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("SeriesNumber")]
        public long SeriesNumberId { get; set; }
        public virtual SeriesNumber SeriesNumber { get; set; }

        public bool IsAttractive { get; set; }

        public long BasePrice { get; set; }
        public long? AuctionedPrice { get; set; }
    }
}
