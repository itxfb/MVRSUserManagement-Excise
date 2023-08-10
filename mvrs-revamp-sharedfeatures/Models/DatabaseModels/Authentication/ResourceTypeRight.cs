using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class ResourceTypeRight : BaseModel
    {
        [Key]
        public long RTRightId { get; set; }

        [ForeignKey("ResourceType")]
        public long ResourceTypeId { get; set; }
        public virtual ResourceType ResourceType { get; set; }

        [Required]
        [StringLength(50)]
        public string RTRightName { get; set; }

        [Required]
        [StringLength(20)]
        public string RTRightNameAbbr { get; set; }

        [Required]
        [StringLength(1024)]
        public string RTRightDescription { get; set; }

        public bool IsGlobalRef { get; set; }

        [ForeignKey("GRight")]
        public long GRightId { get; set; }
        public virtual GlobalRight GRight { get; set; }
    }
}
