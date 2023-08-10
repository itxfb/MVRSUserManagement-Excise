using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleImportInfo : CommonFeature
    {
        [Required]
        public long ImportInfoId { get; set; }

        [Required]
        [StringLength(30)]
        public string ImporterName { get; set; }

        [Required]
        [StringLength(500)]
        public string ImporterAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string IGMNo { get; set; }

        [Required]
        public DateTime IGMDate { get; set; }

        [Required]
        public long? IndexNo { get; set; }

        [Required]
        [StringLength(30)]
        public string PlaceOfIssue { get; set; }

        [Required]
        [StringLength(20)]
        public string ImportPermitNo { get; set; }

        [Required]
        public DateTime? PermitIssueDate { get; set; }

        [Required]
        public long? PortId { get; set; }
        public string Port { get; set; }
        
        [Required]
        public long? ClearingAgentId { get; set; }
        public string ClearingAgent { get; set; }

        [Required]
        public long? CustomCollectorateId { get; set; }
        public string CustomCollectorate { get; set; }

        [Required]
        public long? CountryId { get; set; }
        public string Country { get; set; }

        [Required]
        public long? VehicleSchemeId { get; set; }
        public string VehicleScheme { get; set; }

        [Required]
        public long? ImportValue { get; set; }

        [Required]
        public long? CustomDuty { get; set; }

        [Required]
        public long? SalesTax { get; set; }

        [Required]
        public long? ImportLicenseFee { get; set; }

        [Required]
        public long? Insurrance { get; set; }

        [Required]
        public long? AnyOtherCost { get; set; }

        [Required]
        public long? LandedCost { get; set; }

        [Required]
        public DateTime? PaymentDate { get; set; }
        
        [Required]
        public long? BankId { get; set; }
        public string Bank { get; set; }
    }

}
