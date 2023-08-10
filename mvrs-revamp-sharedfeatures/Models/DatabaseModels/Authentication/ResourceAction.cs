using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Authentication
{
    public class ResourceAction : BaseModel
    {
        [Key]
        public long ResourceActionId { get; set; }
        
        [Required]
        [StringLength(70)]
        public string ActionName { get; set; }
    }
}
