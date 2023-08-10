using Models.ViewModels.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwApplication : CommonFeature
    {
        public long ApplicationId { get; set; }

        public long BusinessProcessId { get; set; }
        public string BusinessProcess { get; set; }

        public long BusinessPhaseId { get; set; }
        public string BusinessPhase { get; set; }

        public long BusinessPhaseStatusId { get; set; }
        public string BusinessPhaseStatus { get; set; }

        public long ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }


        public string CreatedBy { get; set; }

        [JsonIgnore]
        public long? OwnerGroupId { get; set; }

        public DateTime ReceivedAt { get; set; }

        public long OwnerId { get; set; }
        
        [Required]
        public long? OwnerTypeId { get; set; }

        [Required]
        public long? OwnerTaxGroupId { get; set; }

        public long VehicleId { get; set; }

        public VwTempOwner_v1 Owner { get; set; }

        public VwTempOwner_v1 Seller { get; set; }

        public VwVehicle Vehicle { get; set; }
        public VwVehiclePurchaseInfo PurchaseInfo { get; set; }
        public VwHPA HPAInfo { get; set; }
        public VwKeeper Keeper { get; set; }
        public VwAssessment Assessment { get; set; }
        public List<VwVehicleDocumentDetail> Documents { get; set; }
        public List<VwAssessment> TaxAssessment { get; set; }
        public List<VwChallanPaymentInfo> ChallanPayments { get; set; }
    }
}
