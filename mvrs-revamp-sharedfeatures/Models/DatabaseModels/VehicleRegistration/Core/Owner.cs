using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Owner : BaseModel
    {
        [Key]
        public long OwnerId { get; set; }

        [ForeignKey("OwnerType")]
        public long OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }
    }
}
