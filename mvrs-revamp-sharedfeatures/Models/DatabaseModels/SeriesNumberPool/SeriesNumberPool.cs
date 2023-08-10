using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class SeriesNumberPool : BaseModel
    {
        [Key]
        public long SeriesNumberPoolId { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("Series")]
        public long SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("SeriesType")]
        public long SeriesTypeId { get; set; }
        public virtual SeriesType SeriesType { get; set; }

        [ForeignKey("SeriesNumber")]
        public long SeriesNumberId { get; set; }
        public virtual SeriesNumber SeriesNumber { get; set; }

        [ForeignKey("SeriesNumberStatus")]
        public long SeriesNumberStatusId { get; set; }
        public virtual SeriesNumberStatus SeriesNumberStatus { get; set; }

        [ForeignKey("District")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [StringLength(30)]
        public string RegistrationNo { get; set; }

        public long BasePrice { get; set; }
        public long? AuctionedPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsReserved { get; set; }
        public bool IsAlloted { get; set; }
    }
}
