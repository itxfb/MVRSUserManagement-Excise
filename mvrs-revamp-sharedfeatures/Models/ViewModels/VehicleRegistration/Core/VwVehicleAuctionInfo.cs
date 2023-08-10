using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleAuctionInfo : CommonFeature
    {
        [Key]
        public long AuctionInfoId { get; set; }

        [Required]
        [StringLength(50)]
        public string LotNo { get; set; }

        [Required]
        [StringLength(50)]
        public string BatchNo { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryNo { get; set; }

        [Required]
        [StringLength(50)]
        public string VoucherNo { get; set; }

        [Required]
        public DateTime? VoucherDated { get; set; }
    }
}
