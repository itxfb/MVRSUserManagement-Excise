using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.epay
{
    public class Application : BaseModel
    {
        [Key]
        public long ApplicationId { get; set; }

        public long? RegularApplicationId { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("District")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("SiteOffice")]
        public long SiteOfficeId { get; set; }
        public virtual SiteOffice SiteOffice { get; set; }

        public DateTime ReceivedAt { get; set; }
        public bool IsHPA { get; set; }

        [ForeignKey("PaymentStatus")]
        public long PaymentStatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        [StringLength(50)]
        public string PSId { get; set; }
        public long AmountPaid { get; set; }
        public DateTime PaidOn { get; set; }

        [StringLength(50)]
        public string BankCode { get; set; }
    }
}
