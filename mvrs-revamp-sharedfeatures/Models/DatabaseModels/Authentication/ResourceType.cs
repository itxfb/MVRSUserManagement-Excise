using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class ResourceType : BaseModel
    {
        [Key]
        public long ResourceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ResourceTypeName { get; set; }

        [Required]
        [StringLength(20)]
        public string ResourceTypeNameAbbr { get; set; }

        [Required]
        [StringLength(1024)]
        public string ResourceTypeDescription { get; set; }
    }
}
