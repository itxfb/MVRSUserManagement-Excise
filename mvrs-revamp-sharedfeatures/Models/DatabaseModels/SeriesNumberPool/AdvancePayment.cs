using Models.DatabaseModels.VehicleRegistration.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class AdvancePayment : BaseModel
    {
        [Key]
        public long AdvancePaymentId { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }

        [ForeignKey("Series")]
        public long SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("SeriesNumber")]
        public long SeriesNumberId { get; set; }
        public virtual SeriesNumber SeriesNumber { get; set; }

        [ForeignKey("AdvancePaymentStatus")]
        public long AdvancePaymentStatusId { get; set; }
        public virtual AdvancePaymentStatus AdvancePaymentStatus { get; set; }

        [ForeignKey("Challan")]
        public long ChallanId { get; set; }
        public virtual Challan Challan { get; set; }

        [StringLength(50)]
        public string ChasisNumber { get; set; }
        public long BasePrice { get; set; }

        [StringLength(50)]
        public string PSId { get; set; }
        public DateTime PaidOn { get; set; }

        [StringLength(50)]
        public string BankCode { get; set; }

        [StringLength(50)]
        public string OwnerName { get; set; }

        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }
    }
}
