using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleLog : BaseModel
    {
        [Key]
        public long VehicleLogId { get; set; }


        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        //[Required]
        [StringLength(70)]
        public string RegistrationNo { get; set; }

        public DateTime? RegistrationDate { get; set; }

        
        [ForeignKey("District")]
        public long RegistrationDistrictId { get; set; }
        public virtual District District { get; set; }


        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual Owner Owner { get; set; }


        [ForeignKey("VehicleBodyConvention")]
        public long? VehicleBodyConventionId { get; set; }
        public virtual VehicleBodyConvention VehicleBodyConvention { get; set; }


        [ForeignKey("VehicleBodyType")]
        public long? VehicleBodyTypeId { get; set; }
        public virtual VehicleBodyType VehicleBodyType { get; set; }


        [ForeignKey("VehicleCategory")]
        public long? VehicleCategoryId { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }


        [ForeignKey("VehicleClass")]
        public long? VehicleClassId { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }


        [ForeignKey("VehicleClassification")]
        public long? VehicleClassificationId { get; set; }
        public virtual VehicleClassification VehicleClassification { get; set; }


        [ForeignKey("VehicleColor")]
        public long? VehicleColorId { get; set; }
        public virtual VehicleColor VehicleColor { get; set; }


        [ForeignKey("VehicleEngineType")]
        public long? VehicleEngineTypeId { get; set; }
        public virtual VehicleEngineType VehicleEngineType { get; set; }


        [ForeignKey("VehicleFuelType")]
        public long? VehicleFuelTypeId { get; set; }
        public virtual VehicleFuelType VehicleFuelType { get; set; }


        [ForeignKey("VehicleMake")]
        public long? VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }


        [ForeignKey("VehicleMaker")]
        public long? VehicleMakerId { get; set; }
        public virtual VehicleMaker VehicleMaker { get; set; }


        [ForeignKey("VehiclePurchaseType")]
        public long? VehiclePurchaseTypeId { get; set; }
        public virtual VehiclePurchaseType VehiclePurchaseType { get; set; }


        [ForeignKey("VehicleStatus")]
        public long? VehicleStatusId { get; set; }
        public virtual VehicleStatus VehicleStatus { get; set; }


        [ForeignKey("VehicleUsage")]
        public long? VehicleUsageId { get; set; }
        public virtual VehicleUsage VehicleUsage { get; set; }


        [ForeignKey("VehicleRouteType")]
        public long? VehicleRouteTypeId { get; set; }
        public virtual VehicleRouteType VehicleRouteType { get; set; }


        [ForeignKey("VehicleType")]
        public long? VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        public int ManufacturingYear { get; set; }

        public int NoOfCylinder { get; set; }

        public int EngineSize { get; set; }

        public int HorsePower { get; set; }


        [Required]
        [StringLength(50)]
        public string ChasisNo { get; set; }

        [Required]
        [StringLength(30)]
        public string EngineNo { get; set; }

        public int SeatingCapacity { get; set; }

        public long Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public long LadenWeight { get; set; }

        public long UnLadenWeight { get; set; }

        //[Required]
        [StringLength(15)]
        public string WheelBase { get; set; }
    }
}
