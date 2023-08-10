using System;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwDues
    {
        public long DuesId { get; set; }

        public long AssessmentBaseId { get; set; }

        public long DuesTypeId { get; set; }
        public string DuesType { get; set; }

        public long DuesStatusId { get; set; }
        public string DuesStatus { get; set; }

        public long? ChallanId { get; set; }

        public long PaymentStatusId { get; set; }
        public string PaymentStatus { get; set; }

        public long Payable { get; set; }
        public DateTime DueDate { get; set; }
    }
}
