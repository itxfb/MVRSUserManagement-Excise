
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.SeriesNumberPool.Core
{
    public class VwAuctionResult
    {
        public long SeriesNumberPoolId { get; set; }
        public long SeriesCategoryId { get; set; }
        public long SeriesId { get; set; }
        public long SeriesNumberId { get; set; }

        [StringLength(4)]
        public string SeriesNumberName { get; set; }

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
