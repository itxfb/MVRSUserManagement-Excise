using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels.epay
{
    public class VehicleAdditionalInfo : BaseModel
    {
        [Key]
        public long VehicleAdditionalInfoId { get; set; }

        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("VehicleRCStatus")]
        public long? VehicleRCStatusId { get; set; }
        public virtual VehicleRCStatus VehicleRCStatus { get; set; }

        public int TaxFrequency { get; set; }
        public int TaxPeriod { get; set; }
        public bool IsHPA { get; set; }
        public bool? IsTaxExempted { get; set; }
        public bool? IsIncomeTaxExempted { get; set; }
        public DateTime? DateOfFirstRegistration { get; set; }
        public DateTime? FitnessCertValidFrom { get; set; }
        public DateTime? FitnessCertValidTo { get; set; }
        public DateTime? TaxPaidUpto { get; set; }
        public long RegistrationNoPrice { get; set; }
    }
}
