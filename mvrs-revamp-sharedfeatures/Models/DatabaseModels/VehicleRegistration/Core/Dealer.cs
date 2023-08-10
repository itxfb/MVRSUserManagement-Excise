using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class Dealer : BaseModel
    {
        [Key]
        public long DealerId { get; set; }

        [ForeignKey("Business")]
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }

        [StringLength(500)]
        public string AccountPassword { get; set; }
    }
}
