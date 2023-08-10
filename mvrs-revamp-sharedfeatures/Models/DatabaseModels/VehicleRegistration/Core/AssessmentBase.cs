using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class AssessmentBase : BaseModel
    {
        [Key]
        public long AssessmentBaseId { get; set; }

        [ForeignKey("District")]
        public long DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("AssessmentStatus")]
        public long AssessmentStatusId { get; set; }
        public virtual AssessmentStatus AssessmentStatus { get; set; }

        [ForeignKey("BusinessProcess")]
        public long BusinessProcessId { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }

        [ForeignKey("Application")]
        public long? ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("VehicleCategory")]
        public long VehicleCategoryId { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }

        [ForeignKey("VehicleClass")]
        public long VehicleClassId { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }

        [ForeignKey("VehicleClassDetail")]
        public long VehicleClassDetailId { get; set; }
        public virtual VehicleClassDetail VehicleClassDetail { get; set; }

        [ForeignKey("VehicleClassification")]
        public long? VehicleClassificationId { get; set; }
        public virtual VehicleClassification VehicleClassification { get; set; }

        [ForeignKey("VehicleBodyType")]
        public long VehicleBodyTypeId { get; set; }
        public virtual VehicleBodyType VehicleBodyType { get; set; }

        [ForeignKey("VehicleUsage")]
        public long VehicleUsageId { get; set; }
        public virtual VehicleUsage VehicleUsage { get; set; }

        [ForeignKey("VehicleStatus")]
        public long? VehicleStatusId { get; set; }
        public virtual VehicleStatus VehicleStatus { get; set; }

        [ForeignKey("VehiclePurchaseType")]
        public long VehiclePurchaseTypeId { get; set; }
        public virtual VehiclePurchaseType VehiclePurchaseType { get; set; }

        public int EngineSize { get; set; }
        public int SeatingCapacity { get; set; }
        public long Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long LadenWeight { get; set; }
        public long UnLadenWeight { get; set; }
        public bool IsHPA { get; set; }
        public long RegistrationNoPrice { get; set; }

        [StringLength(70)]
        public string RegistrationNo { get; set; }
        public int TaxFrequency { get; set; }
        public DateTime? TaxPaidUpto { get; set; }
        public DateTime? DateOfFirstRegistration { get; set; }
        public bool? IsTaxExempted { get; set; }
        public bool? IsIncomeTaxExempted { get; set; }
        public DateTime? FitnessCertValidFrom { get; set; }
        public DateTime? FitnessCertValidTo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime ApplicationReceivedAt { get; set; }
        public char IsFiler { get; set; }
        public int TaxPeriod { get; set; }
    }
}
