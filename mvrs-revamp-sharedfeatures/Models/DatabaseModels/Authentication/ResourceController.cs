using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Authentication
{
    public class ResourceController : BaseModel
    {
        [Key]
        public long ResourceControllerId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ControllerName { get; set; }
    }
}
