using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class Resource : BaseModel
    {
        [Key]
        public long ResourceId { get; set; }

        [Required]
        [ForeignKey("ResourceType")]
        public long ResourceTypeId { get; set; }
        public virtual ResourceType ResourceType { get; set; }

        [Required]
        [StringLength(50)]
        public string ResourceName { get; set; }

        [Required]
        [StringLength(20)]
        public string ResourceNameAbbr { get; set; }

        [Required]
        [StringLength(1024)]
        public string ResourceDescription { get; set; }

        [Required]
        [StringLength(2048)]
        public string ResourceEndPoint { get; set; }

        [ForeignKey("ResourceController")]
        public long? ControllerId { get; set; }
        public virtual ResourceController ResourceController { get; set; }

        [ForeignKey("ResourceAction")]
        public long? ActionId { get; set; }
        public virtual ResourceAction ResourceAction { get; set; }
    }
}
