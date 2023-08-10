using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleImportInfo : BaseModel
    {
        [Key]
        public long VehicleImportInfoId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        [StringLength(30)]
        public string ImporterName { get; set; }

        [Required]
        [StringLength(500)]
        public string ImporterAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string IGMNo { get; set; }

        public DateTime IGMDate { get; set; }

        public long IndexNo { get; set; }

        [Required]
        [StringLength(30)]
        public string PlaceOfIssue { get; set; }

        [Required]
        [StringLength(20)]
        public string ImportPermitNo { get; set; }

        public DateTime PermitIssueDate { get; set; }

        [ForeignKey("Port")]
        public long PortId { get; set; }
        public virtual Port Port { get; set; }

        [ForeignKey("ClearingAgent")]
        public long ClearingAgentId { get; set; }
        public virtual ClearingAgent ClearingAgent { get; set; }

        [ForeignKey("CustomCollectorate")]
        public long CustomCollectorateId { get; set; }
        public virtual CustomCollectorate CustomCollectorate { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("VehicleScheme")]
        public long VehicleSchemeId { get; set; }
        public virtual VehicleScheme VehicleScheme { get; set; }

        public long ImportValue { get; set; }

        public long CustomDuty { get; set; }

        public long SalesTax { get; set; }

        public long ImportLicenseFee { get; set; }

        public long Insurrance { get; set; }

        public long AnyOtherCost { get; set; }

        public long LandedCost { get; set; }

        public DateTime PaymentDate { get; set; }

        [ForeignKey("Bank")]
        public long BankId { get; set; }
        public virtual Bank Bank { get; set; }
    }

}
