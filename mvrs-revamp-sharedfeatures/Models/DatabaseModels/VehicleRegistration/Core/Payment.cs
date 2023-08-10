using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class PaymentInfo : BaseModel
    {
        [Key]
        public long PaymentInfoId { get; set; }

        [ForeignKey("Challan")]
        public long ChallanId { get; set; }
        public virtual Challan Challan { get; set; }

        [ForeignKey("PaymentMode")]
        public long PaymentModeId { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }

        [ForeignKey("PaymentStatus")]
        public long PaymentStatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        [StringLength(50)]
        public string PSId { get; set; }
        public long AmountPaid { get; set; }
        public DateTime PaidOn { get; set; }

        [StringLength(50)]
        public string BankCode { get; set; }

        public long? CashReceivedBy { get; set; }
    }
}
