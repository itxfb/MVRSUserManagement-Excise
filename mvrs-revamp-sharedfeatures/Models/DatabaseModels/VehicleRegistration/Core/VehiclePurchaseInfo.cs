using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehiclePurchaseInfo : BaseModel
    {
        [Key]
        public long VehiclePurchaseInfoId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("VehicleScheme")]
        public long VehicleSchemeId { get; set; }
        public virtual VehicleScheme VehicleScheme { get; set; }

        [ForeignKey("Dealer")]
        public long DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        [Required]
        [StringLength(100)]
        public string CertificateNo { get; set; }

        [Required]
        public DateTime CertificateDated { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime InvoiceDated { get; set; }
    }
}
