using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Keeper : BaseModel
    {
        [Key]
        public long KeeperId { get; set; }

        [ForeignKey("Owner")]
        public long? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Vehicle")]
        public long? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Person")]
        public long? KeeperPersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
