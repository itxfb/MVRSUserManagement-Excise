using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Payment
{
    public class VwPayeeIntimation
    {
        public long ApplicationId { get; set; }
        public long ChallanId { get; set; }

        [StringLength(50)]
        public string PSId { get; set; }
        public long AmountPaid { get; set; }
        public DateTime PaidOn { get; set; }

        [StringLength(50)]
        public string BankCode { get; set; }
    }
}
