using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class ResourceTypeDefaultRight : BaseModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("RTRight")]
        public long RTRightId { get; set; }
        public virtual ResourceTypeRight RTRight { get; set; }

        [ForeignKey("DefaultRTRight")]
        public long DefaultRTRightId { get; set; }
        public virtual ResourceTypeRight DefaultRTRight { get; set; }
    }
}
