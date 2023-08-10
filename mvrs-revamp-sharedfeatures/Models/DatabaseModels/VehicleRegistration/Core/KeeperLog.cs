using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class KeeperLog : BaseModel
    {
        [Key]
        public long KeeperLogId { get; set; }

        [ForeignKey("Keeper")]
        public long KeeperId { get; set; }
        public virtual Keeper Keeper { get; set; }
        
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
