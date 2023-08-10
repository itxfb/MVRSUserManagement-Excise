using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicle : CommonFeature
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? ApplicationPhaseId { get; set; }

        public long? VehicleId { get; set; }

        //[Required]
        [StringLength(70)]
        public string RegistrationNo { get; set; }

        public DateTime? RegistrationDate { get; set; }

        //[Required]
        public long? DistrictId { get; set; }

        public long VehicleClassGroupId { get; set; }
        public string VehicleClassGroup { get; set; }

        [Required]
        public long? VehicleBodyConventionId { get; set; }
        public string VehicleBodyConvention { get; set; }

        //[Required]
        public long? VehicleBodyTypeId { get; set; }
        public string VehicleBodyType { get; set; }

        //[Required]
        public long? VehicleCategoryId { get; set; }
        public string VehicleCategory { get; set; }

        [Required]
        public long? VehicleClassId { get; set; }
        public string VehicleClass { get; set; }

        //[Required]
        public long? VehicleClassificationId { get; set; }
        public string VehicleClassification { get; set; }

        [Required]
        public long? VehicleColorId { get; set; }
        public string VehicleColor { get; set; }

        //[Required]
        public long? VehicleEngineTypeId { get; set; }
        public string VehicleEngineType { get; set; }

        [Required]
        public long? VehicleFuelTypeId { get; set; }
        public string VehicleFuelType { get; set; }

        [Required]
        public long? VehicleMakeId { get; set; }
        public string VehicleMake { get; set; }

        [Required]
        public long? VehicleMakerId { get; set; }
        public string VehicleMaker { get; set; }

        [Required]
        public long? VehiclePurchaseTypeId { get; set; }
        public string VehiclePurchaseType { get; set; }

        //[Required]
        public long? VehicleStatusId { get; set; }
        public string VehicleStatus { get; set; }

        //[Required]
        public long? VehicleUsageId { get; set; }
        public string VehicleUsage { get; set; }

        public long? VehicleTypeId { get; set; }
        public string VehicleType { get; set; }

        [Required]
        public int? ManufacturingYear { get; set; }

        //[Required]
        public int? NoOfCylinder { get; set; }

        [Required]
        public int? EngineSize { get; set; }

        [Required]
        public int? HorsePower { get; set; }

        [Required]
        public long? MotorPower { get; set; }

        [Required]
        public long? BatteryCapacity { get; set; }

        [Required]
        [StringLength(200)]
        public string ChasisNo { get; set; }

        [Required]
        [StringLength(30)]
        public string EngineNo { get; set; }

        [Required]
        public int? SeatingCapacity { get; set; }

        [Required]
        public long? Price { get; set; }

        [Required]
        public DateTime? PurchaseDate { get; set; }

        public long? LadenWeight { get; set; }

        public long? UnLadenWeight { get; set; }

        [StringLength(15)]
        public string WheelBase { get; set; }


        //[Required]
        public long? VehicleRCStatusId { get; set; }
        public string VehicleRCStatus { get; set; }

        public int TaxFrequency { get; set; }
        public int TaxPeriod { get; set; }

        public bool IsHPA { get; set; }

        [Required]
        public bool? IsCVTPaid { get; set; }
        public bool? IsTaxExempted { get; set; }
        public bool? IsIncomeTaxExempted { get; set; }
        public DateTime? DateOfFirstRegistration { get; set; }
        public DateTime? FitnessCertValidFrom { get; set; }
        public DateTime? FitnessCertValidTo { get; set; }
        public DateTime? TaxPaidUpto { get; set; }
        public long RegistrationNoPrice { get; set; }
    }
}
