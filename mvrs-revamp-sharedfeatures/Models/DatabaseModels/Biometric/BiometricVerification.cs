using Models.DatabaseModels.VehicleRegistration.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Biometric
{
    public class BiometricVerification : BaseModel
    {
        [Key]
        public long BiometricVerificationId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("OwnerGroup")]
        public long OwnerGroupId { get; set; }
        public virtual OwnerGroup OwnerGroup { get; set; }

        [ForeignKey("Person")]
        public long? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public bool IsBuyer { get; set; }

        [ForeignKey("NadraFranchise")]
        public long? NadraFranchiseId { get; set; }
        public virtual NadraFranchise NadraFranchise { get; set; }

        public long? NadraTransId { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? VerificationReportedOn { get; set; }
    }
}