using Models.DatabaseModels.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Setup
{
    public class TaxRate : SetupBaseModel
    {
        [ForeignKey("VehicleClass")]
        public long VehicleClassId { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }

        [ForeignKey("VehicleClassDetail")]
        public long VehicleClassDetailId { get; set; }
        public virtual VehicleClassDetail VehicleClassDetail { get; set; }

        [ForeignKey("TaxType")]
        public long TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }

        [ForeignKey("TaxBase")]
        public long TaxBaseId { get; set; }
        public virtual TaxBase TaxBase { get; set; }

        public decimal TaxValue { get; set; }
    }
}
