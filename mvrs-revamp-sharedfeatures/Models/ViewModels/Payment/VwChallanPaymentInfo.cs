using Models.ViewModels.VehicleRegistration.Core;
using System;
using System.Collections.Generic;

namespace Models.ViewModels.Payment
{
    public class VwChallanPaymentInfo
    {
        public long ApplicationId { get; set; }
        public long ChallanId { get; set; }
        public long AssessmentBaseId { get; set; }
        public long PaymentInfoId { get; set; }

        public long ChallanTypeId { get; set; }
        public string ChallanType { get; set; }

        public long ChallanStatusId { get; set; }
        public string ChallanStatus { get; set; }
        public long TotalAmount { get; set; }

        public long PaymentModeId { get; set; }
        public string PaymentMode { get; set; }

        public long PaymentStatusId { get; set; }
        public string PaymentStatus { get; set; }

        public string PSId { get; set; }
        public long AmountPaid { get; set; }
        public DateTime PaidOn { get; set; }


        public List<VwAssessment> TaxAssessment { get; set; }
    }
}
