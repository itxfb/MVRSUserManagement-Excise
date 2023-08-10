using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleAuctionInfo : BaseModel
    {
        [Key]
        public long VehicleAuctionInfoId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

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
        public DateTime VoucherDated { get; set; }
    }
}
