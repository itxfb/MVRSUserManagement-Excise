using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleLocalPurchaseInfo : CommonFeature
    {
        public long LocalPurchaseInfoId { get; set; }

        [Required]
        public long? VehicleSchemeId { get; set; }
        public string VehicleScheme { get; set; }

        [Required]
        public long? DealerId { get; set; }
        public string DealerName { get; set; }

        [Required]
        [StringLength(100)]
        public string CertificateNo { get; set; }

        [Required]
        public DateTime? CertificateDated { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime? InvoiceDated { get; set; }
    }
}
