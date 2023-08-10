using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleOwnershipHistory : BaseModel
    {
        [Key]
        public long VehicleOwnershipHistoryId { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Seller")]
        public long? SellerId { get; set; }
        public virtual Owner Seller { get; set; }

        [ForeignKey("Buyer")]
        public long BuyerId { get; set; }
        public virtual Owner Buyer { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        public DateTime EffectedDate { get; set; }
    }
}
