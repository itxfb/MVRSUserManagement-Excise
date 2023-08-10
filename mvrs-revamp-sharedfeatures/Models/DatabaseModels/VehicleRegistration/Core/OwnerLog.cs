using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class OwnerLog : BaseModel
    {
        [Key]
        public long OwnerLogId { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("OwnerType")]
        public long OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }
    }
}
