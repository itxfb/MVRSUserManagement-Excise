using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class AuctionResult : BaseModel
    {
        [Key]
        public long AuctionResultId { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("Series")]
        public long SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("SeriesNumber")]
        public long SeriesNumberId { get; set; }
        public virtual SeriesNumber SeriesNumber { get; set; }

        public long AuctionedValue { get; set; }

        [StringLength(30)]
        public string WinnerAIN { get; set; }

        [StringLength(50)]
        public string ChasisNumber { get; set; }

        [StringLength(50)]
        public string OwnerName { get; set; }

        [StringLength(50)]
        public string WinnerName { get; set; }

        [StringLength(50)]
        public string FatherHusbandName { get; set; }

        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
